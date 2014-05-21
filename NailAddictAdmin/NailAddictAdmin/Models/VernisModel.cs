using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailAddictAdmin.Models
{
    public class VernisModel : INotifyPropertyChanged
    {
        #region Fields
        private int _Id;
        public int Id {
            get { return _Id; }
            set
            {
                _Id = value;
                NotifyPropertyChanged("Id");
            }
        }

        private string _Marque;
        public string Marque
        {
            get { return _Marque; }
            set
            {
                _Marque = value;
                NotifyPropertyChanged("Marque");
            }
        }

        private string _Texture;
        public string Texture
        {
            get { return _Texture; }
            set
            {
                _Texture = value;
                NotifyPropertyChanged("Texture");
            }
        }

        private string _Couleur;
        public string Couleur
        {
            get { return _Couleur; }
            set
            {
                _Couleur = value;
                NotifyPropertyChanged("Couleur");
            }
        }

        private string _Reference;
        public string Reference
        {
            get { return _Reference; }
            set
            {
                _Reference = value;
                NotifyPropertyChanged("Reference");
            }
        }

        private string _LienVernis;
        public string LienVernis
        {
            get { return _LienVernis; }
            set
            {
                _LienVernis = value;
                NotifyPropertyChanged("LienVernis");
            }
        }
        private string _Prix;
        public string Prix
        {
            get { return _Prix; }
            set
            {
                _Prix = value;
                NotifyPropertyChanged("Prix");
            }
        }


        private string _Magasin;
        public string Magasin
        {
            get { return _Magasin; }
            set
            {
                _Magasin = value;
                NotifyPropertyChanged("Magasin");
            }
        }

        private bool _Valide;
        public bool Valide
        {
            get { return _Valide; }
            set
            {
                _Valide = value;
                NotifyPropertyChanged("Valide");
            }
        }
        #endregion

        #region Init
        public  VernisModel(MySqlDataReader user )
        {
            Id = Convert.ToInt32(user["id_vernis"]);
            Marque = Convert.ToString(user["marque"]);
            Texture = Convert.ToString(user["texture"]);
            Couleur = Convert.ToString(user["couleur"]);
            Reference = Convert.ToString(user["reference"]);
            LienVernis = Convert.ToString(user["lien_vernis"]);
            Prix = Convert.ToString(user["valeur"]);
            Magasin = Convert.ToString(user["nom_magasin"]);
            Valide = Convert.ToBoolean(user["valide"]);
        }
        public VernisModel(MySqlDataReader vernis, bool b)
        {
            Id = Convert.ToInt32(vernis["id_vernis"]);
        }
        public VernisModel()
        {
            
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
    }
}
