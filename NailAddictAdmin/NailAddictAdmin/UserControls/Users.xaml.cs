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
    /// Logique d'interaction pour Users.xaml
    /// </summary>
    public partial class Users : UserControl, INotifyPropertyChanged
    {
        #region Init
        public Users()
        {
            InitializeComponent();
        }

        public Users(List<Utilisateur> users)
        {
            InitializeComponent();
            UsersCollection = new ObservableCollection<Utilisateur>(users);
        }
        #endregion

        #region Fields
        private ObservableCollection<Utilisateur> _UsersCollection;
        public ObservableCollection<Utilisateur> UsersCollection
        {
            get
            {
                if (_UsersCollection == null)
                    _UsersCollection = new ObservableCollection<Utilisateur>();
                return _UsersCollection;
            }
            set
            {
                _UsersCollection = value;
                NotifyPropertyChanged("UsersCollection");
            }
        }

        private Utilisateur _UtilisateurSelected;
        public Utilisateur UtilisateurSelected
        {
            get
            {
                return _UtilisateurSelected;
            }
            set
            {
                _UtilisateurSelected = value;
                NotifyPropertyChanged("UtilisateurSelected");
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
            if (UtilisateurSelected != null)
            {
                List<VernisModel> listVernis = new List<VernisModel>();
                if (MessageBox.Show("Voulez vous vraiment suppimer ce user?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //Requête supp user
                    try
                    {
                        if (MainWindow.Connexion.State == System.Data.ConnectionState.Open)
                        {
                            MySqlCommand cmd = null;
                            MySqlDataReader dataReader = null;
                            string query = null;
                            // Recup des vernis
                            query = "SELECT collection.id_vernis FROM  utilisateur JOIN collection ON utilisateur.id_user = collection.id_user WHERE utilisateur.id_user = " + UtilisateurSelected.Id;
                            cmd = new MySqlCommand(query, MainWindow.Connexion);
                            dataReader = cmd.ExecuteReader();
                            while (dataReader.Read())
                            {
                                listVernis.Add(new VernisModel(dataReader, true));
                            }
                            dataReader.Close();

                            if (listVernis.Count != 0)
                            {
                                //Delete Vernis/User collection
                                query = "DELETE FROM collection WHERE id_user = " + UtilisateurSelected.Id;
                                cmd = new MySqlCommand(query, MainWindow.Connexion);
                                dataReader = cmd.ExecuteReader();
                                dataReader.Close();

                                foreach (var vernis in listVernis)
                                {
                                    //Delete vernis
                                    query = "DELETE FROM vernis WHERE id_vernis = " + vernis.Id;
                                    cmd = new MySqlCommand(query, MainWindow.Connexion);
                                    dataReader = cmd.ExecuteReader();
                                    dataReader.Close();
                                }
                            }

                            //Delete user
                            query = "DELETE FROM utilisateur WHERE id_user = " + UtilisateurSelected.Id;
                            cmd = new MySqlCommand(query, MainWindow.Connexion);
                            dataReader = cmd.ExecuteReader();
                            dataReader.Close();

                            Refresh();
                        }

                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void Refresh()
        {
            List<Utilisateur> listUsers = new List<Utilisateur>();
            try
            {
                if (MainWindow.Connexion.State == System.Data.ConnectionState.Open)
                {

                    string query = null;
                    query = "SELECT * FROM utilisateur JOIN localisation ON id_localisation_user = id_localisation";


                    MySqlCommand cmd = new MySqlCommand(query, MainWindow.Connexion);

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        listUsers.Add(new Utilisateur(dataReader));
                    }
                    UsersCollection = new ObservableCollection<Utilisateur>(listUsers);
                    dataReader.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menu_vernis_Click(object sender, RoutedEventArgs e)
        {
            UserControl uc_Vernis= null;
            List<VernisModel> listVernis = new List<VernisModel>();
            try
            {
                if (MainWindow.Connexion.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT * FROM utilisateur JOIN collection ON utilisateur.id_user = collection.id_user JOIN vernis ON collection.id_vernis = vernis.id_vernis JOIN prix ON id_prix_vernis = id_prix JOIN magasin ON id_magasin_vernis = id_magasin WHERE utilisateur.id_user="+ UtilisateurSelected.Id;
                    MySqlCommand cmd = new MySqlCommand(query, MainWindow.Connexion);

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        listVernis.Add(new VernisModel(dataReader));
                    }

                    dataReader.Close();

                    if (listVernis != null)
                        uc_Vernis = new Vernis(listVernis, false);

                    if(uc_Vernis!=null)
                    {
                        var apercu = new ApercuWindows();
                        apercu.Uc_Apercu = uc_Vernis;
                        apercu.Height = 600;
                        apercu.Width = 800;
                        apercu.Show();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menu_media_Click(object sender, RoutedEventArgs e)
        {
            UserControl uc_Media = null;
            List<MediaModel> listVernis = new List<MediaModel>();
            try
            {
                if (MainWindow.Connexion.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT * FROM media WHERE id_user=" + UtilisateurSelected.Id ;
                    MySqlCommand cmd = new MySqlCommand(query, MainWindow.Connexion);

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        listVernis.Add(new MediaModel(dataReader));
                    }

                    dataReader.Close();

                    if (listVernis != null)
                        uc_Media = new Media(listVernis, false);

                    if (uc_Media != null)
                    {
                        var apercu = new ApercuWindows();
                        apercu.Uc_Apercu = uc_Media;
                        apercu.Height = 600;
                        apercu.Width = 800;
                        apercu.Show();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
