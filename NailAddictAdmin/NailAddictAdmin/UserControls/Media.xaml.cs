using MySql.Data.MySqlClient;
using NailAddictAdmin.Models;
using NailAddictAdmin.UserControls.Apercu;
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
    /// Logique d'interaction pour Media.xaml
    /// </summary>
    public partial class Media : UserControl, INotifyPropertyChanged
    {
        private int SimpleUserId;
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

        #region Init
        public Media()
        {
            InitializeComponent();
        }
        public Media(List<MediaModel> media, bool valide, int simpleUser = 0)
        {
            InitializeComponent();
            MediaCollection = new ObservableCollection<MediaModel>(media);
            VisibilityValide = valide;
            Action = valide ? "Validation" : "Gestion";
            SimpleUserId = simpleUser;
        }
        #endregion

        #region Fields
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
        private ObservableCollection<MediaModel> _MediaCollection;
        public ObservableCollection<MediaModel> MediaCollection
        {
            get
            {
                if (_MediaCollection == null)
                    _MediaCollection = new ObservableCollection<MediaModel>();
                return _MediaCollection;
            }
            set
            {
                _MediaCollection = value;
                NotifyPropertyChanged("MediaCollection");
            }
        }

        private MediaModel _MediaSelected;
        public MediaModel MediaSelected
        {
            get
            {
                if (_MediaSelected == null)
                    _MediaSelected = new MediaModel();
                return _MediaSelected;
            }
            set
            {
                _MediaSelected = value;
                NotifyPropertyChanged("MediaSelected");
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
            if (MessageBox.Show("Voulez vous vraiment suppimer ce media?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //Requête supp media
                try
                {
                    if (MainWindow.Connexion.State == System.Data.ConnectionState.Open)
                    {
                        string query = "DELETE FROM media WHERE id_media = " + MediaSelected.Id;
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
        }

        private void btn_Valide_Click(object sender, RoutedEventArgs e)
        {
            //Requête valide media
            try
            {
                if (MainWindow.Connexion.State == System.Data.ConnectionState.Open)
                {
                    string query = "UPDATE media SET valide='1' WHERE id_media = " + MediaSelected.Id;
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
            List<MediaModel> listMedia = new List<MediaModel>();
            try
            {
                if (MainWindow.Connexion.State == System.Data.ConnectionState.Open)
                {

                    string query = null;
                    if (SimpleUserId != 0)
                        query = "SELECT * FROM media WHERE id_user="+SimpleUserId;
                    else
                    {
                        if (valide)
                            query = "SELECT * FROM media WHERE valide=0  ORDER BY date_creation";
                        else
                            query = "SELECT * FROM media ORDER BY date_creation";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, MainWindow.Connexion);

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        listMedia.Add(new MediaModel(dataReader));
                    }
                    MediaCollection = new ObservableCollection<MediaModel>(listMedia);
                    dataReader.Close();

                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGrid_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MediaSelected != null)
            {
                var apercu = new ApercuWindows();
                apercu.Uc_Apercu = new ApercuMedia(MediaSelected);
                apercu.Height = 600;
                apercu.Width = 560;
                apercu.Show();
            }
        }
    }
}
