using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NailAddictAdmin.Models
{
    [TypeConverter(typeof(DataGridTextColumn))]
    public class Utilisateur : INotifyPropertyChanged
    {
        private int _Id;
        public int Id {
            get { return _Id; }
            set
            {
                _Id = value;
                NotifyPropertyChanged("Id");
            }
        }

        private string _Nom;
        public string Nom
        {
            get { return _Nom; }
            set
            {
                _Nom = value;
                NotifyPropertyChanged("Nom");
            }
        }

        private string _Prenom;
        public string Prenom
        {
            get { return _Prenom; }
            set
            {
                _Prenom = value;
                NotifyPropertyChanged("Prenom");
            }
        }

        private string _Pseudo;
        public string Pseudo
        {
            get { return _Pseudo; }
            set
            {
                _Pseudo = value;
                NotifyPropertyChanged("Pseudo");
            }
        }

        private string _DateDeNaissance;
        public string DateDeNaissance
        {
            get { return _DateDeNaissance; }
            set
            {
                _DateDeNaissance = value;
                NotifyPropertyChanged("DateDeNaissance");
            }
        }

        private string _LienPhoto;
        public string LienPhoto
        {
            get { return _LienPhoto; }
            set
            {
                _LienPhoto = value;
                NotifyPropertyChanged("LienPhoto");
            }
        }
        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                NotifyPropertyChanged("Description");
            }
        }


        private string _Localisation;
        public string Localisation
        {
            get { return _Localisation; }
            set
            {
                _Localisation = value;
                NotifyPropertyChanged("Localisation");
            }
        }

        public  Utilisateur(MySqlDataReader user )
        {
            Id = Convert.ToInt32(user["id_user"]);
            Nom = Convert.ToString(user["nom"]);
            Prenom = Convert.ToString(user["prenom"]);
            Pseudo = Convert.ToString(user["pseudo"]);
            DateDeNaissance = Convert.ToString(user["date_naissance"]);
            LienPhoto = Convert.ToString(user["lien_photo"]);
            Description = Convert.ToString(user["description_user"]);
            Localisation = Convert.ToString(user["ville"]);
        }
        public Utilisateur()
        {
            
        }
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
    }
}
