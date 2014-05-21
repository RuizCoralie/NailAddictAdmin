using MySql.Data.MySqlClient;
using NailAddictAdmin.Models;
using NailAddictAdmin.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace NailAddictAdmin
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,  INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateConnexion();
            Uc_Admin = new Home();
        }

        private static MySqlConnection _Connexion;
        public static MySqlConnection Connexion
        {
            get {
                if (_Connexion == null)
                    _Connexion = new MySqlConnection();
                return _Connexion; 
            }
            set
            {
                _Connexion = value;
            }
        }


        private UserControl _Uc_Admin;
        public UserControl Uc_Admin
        {
            get
            {
                return _Uc_Admin;
            }
            set
            {
                _Uc_Admin = value;
                NotifyPropertyChanged("Uc_Admin");
            }
        }
        #region Methods
        private void CreateConnexion()
        {
            string server = "127.0.0.1";
            string database = "nail";
            string uid = "root";
            string password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            try
            {
                Connexion = new MySqlConnection(connectionString);
                Connexion.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void btn_UserAll_Click(object sender, RoutedEventArgs e)
        {
            List<Utilisateur> listUser = new List<Utilisateur>();
            try
            {
                
                if(Connexion.State== System.Data.ConnectionState.Open)
                {
                    string query = "SELECT * FROM utilisateur JOIN localisation ON id_localisation_user = id_localisation ";
                    MySqlCommand cmd = new MySqlCommand(query, Connexion);

                    MySqlDataReader dataReader =cmd.ExecuteReader();
                        
                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        listUser.Add(new Utilisateur(dataReader));
                    }

                    dataReader.Close(); 
                 
                    if(listUser !=null)
                        Uc_Admin = new Users(listUser);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_VernisAll_Click(object sender, RoutedEventArgs e)
        {
            List<VernisModel> listVernis = new List<VernisModel>();
            try
            {

                if (Connexion.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT * FROM prix JOIN vernis on id_prix_vernis = id_prix JOIN magasin on id_magasin_vernis = id_magasin";
                    MySqlCommand cmd = new MySqlCommand(query, Connexion);

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        listVernis.Add(new VernisModel(dataReader));
                    }

                    dataReader.Close();

                    if (listVernis != null)
                        Uc_Admin = new Vernis(listVernis,false);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_VernisValider_Click(object sender, RoutedEventArgs e)
        {
            List<VernisModel> listVernis = new List<VernisModel>();
            try
            {
                if (Connexion.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT * FROM prix JOIN vernis on id_prix_vernis = id_prix JOIN magasin on id_magasin_vernis = id_magasin WHERE valide = 0 " ;
                    MySqlCommand cmd = new MySqlCommand(query, Connexion);

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        listVernis.Add(new VernisModel(dataReader));
                    }

                    dataReader.Close();

                    if (listVernis != null)
                        Uc_Admin = new Vernis(listVernis, true);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btn_MediaAll_Click(object sender, RoutedEventArgs e)
        {
            List<MediaModel> listMedia = new List<MediaModel>();
            try
            {
                if (Connexion.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT * FROM media ORDER BY date_creation";
                    MySqlCommand cmd = new MySqlCommand(query, Connexion);

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        listMedia.Add(new MediaModel(dataReader));
                    }

                    dataReader.Close();

                    if (listMedia != null)
                        Uc_Admin = new Media(listMedia, false);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_MediaValider_Click(object sender, RoutedEventArgs e)
        {
            List<MediaModel> listMedia = new List<MediaModel>();
            try
            {
                if (Connexion.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT * FROM media WHERE valide=0  ORDER BY date_creation";
                    MySqlCommand cmd = new MySqlCommand(query, Connexion);

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        listMedia.Add(new MediaModel(dataReader));
                    }

                    dataReader.Close();

                    if (listMedia != null)
                        Uc_Admin = new Media(listMedia, true);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //close connection
            Connexion.Close();
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            Uc_Admin = new Home();
        }
    }
}
