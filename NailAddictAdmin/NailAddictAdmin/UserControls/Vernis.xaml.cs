using MySql.Data.MySqlClient;
using NailAddictAdmin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NailAddictAdmin.UserControls
{
    /// <summary>
    /// Logique d'interaction pour Vernis.xaml
    /// </summary>
    public partial class Vernis : UserControl, INotifyPropertyChanged
    {
       
        #region Init
        public Vernis()
        {
            InitializeComponent();
        }
        public Vernis(List<VernisModel> vernis, bool valide)
        {
            InitializeComponent();
            VernisCollection = new ObservableCollection<VernisModel>(vernis);
            VisibilityValide = valide;
            Action = valide ? "Validation" : "Gestion";
        }
        #endregion

        #region Fields
        private bool _VisibilityValide;
        public bool VisibilityValide
        {
            get { return _VisibilityValide; }
            set
            {
                _VisibilityValide = value;
                NotifyPropertyChanged("VisibilityValide");
            }
        }
        private string _Action;
        public string Action
        {
            get { return _Action; }
            set
            {
                _Action = value;
                NotifyPropertyChanged("Action");
            }
        }

        private ObservableCollection<VernisModel> _VernisCollection;
        public ObservableCollection<VernisModel> VernisCollection
        {
            get
            {
                if (_VernisCollection == null)
                    _VernisCollection = new ObservableCollection<VernisModel>();
                return _VernisCollection;
            }
            set
            {
                _VernisCollection = value;
                NotifyPropertyChanged("VernisCollection");
            }
        }

        private VernisModel _VernisSelected;
        public VernisModel VernisSelected
        {
            get
            {
                if (_VernisSelected == null)
                    _VernisSelected = new VernisModel();
                return _VernisSelected;
            }
            set
            {
                _VernisSelected = value;
                NotifyPropertyChanged("VernisSelected");
            }
        }
        #endregion

        #region Implemente INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private void btn_Supp_Click(object sender, RoutedEventArgs e)
        {
            List<VernisModel> listVernis = new List<VernisModel>();
            try
            {
                if (MainWindow.Connexion.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = null;
                    MySqlDataReader dataReader = null;
                    string query = null;

                    //Delete Vernis collection
                    query = "DELETE FROM collection WHERE id_vernis = " + VernisSelected.Id;
                    cmd = new MySqlCommand(query, MainWindow.Connexion);
                    dataReader = cmd.ExecuteReader();                
                    dataReader.Close();

                    //Delete Vernis
                    query = "DELETE FROM vernis WHERE id_vernis = " + VernisSelected.Id;
                    cmd = new MySqlCommand(query, MainWindow.Connexion);
                    dataReader = cmd.ExecuteReader();
                    dataReader.Close();

                    Refresh(false);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Valide_Click(object sender, RoutedEventArgs e)
        {
            //Requête valide vernis

            List<VernisModel> listVernis = new List<VernisModel>();
            try
            {
                if (MainWindow.Connexion.State == System.Data.ConnectionState.Open)
                {
                    string query = "UPDATE vernis SET valide='1' WHERE id_vernis = "+ VernisSelected.Id;
                    MySqlCommand cmd = new MySqlCommand(query, MainWindow.Connexion);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Close();

                    Refresh(true);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Refresh(bool valide)
        {
            List<VernisModel> listVernis = new List<VernisModel>();
            try
            {
                if (MainWindow.Connexion.State == System.Data.ConnectionState.Open)
                {

                    string query = null;
                    if(valide)
                        query = "SELECT * FROM prix JOIN vernis on id_prix_vernis = id_prix JOIN magasin on id_magasin_vernis = id_magasin WHERE valide = 0 ";
                    else
                        query = "SELECT * FROM prix JOIN vernis on id_prix_vernis = id_prix JOIN magasin on id_magasin_vernis = id_magasin";

                    MySqlCommand cmd = new MySqlCommand(query, MainWindow.Connexion);

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        listVernis.Add(new VernisModel(dataReader));
                    }
                    VernisCollection = new ObservableCollection<VernisModel>(listVernis);
                    dataReader.Close();

                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
