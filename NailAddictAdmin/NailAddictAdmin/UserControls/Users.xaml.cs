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
                if (_UtilisateurSelected == null)
                    _UtilisateurSelected = new Utilisateur();
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
            //Requête supp user
        }
    }
}
