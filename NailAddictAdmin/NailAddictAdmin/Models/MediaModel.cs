using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailAddictAdmin.Models
{
    public class MediaModel : INotifyPropertyChanged
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

        private string _LienMedia;
        public string LienMedia
        {
            get { return _LienMedia; }
            set
            {
                _LienMedia = value;
                NotifyPropertyChanged("LienMedia");
            }
        }

        private string _Type;
        public string Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
                NotifyPropertyChanged("Type");
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
        public  MediaModel(MySqlDataReader user )
        {
            Id = Convert.ToInt32(user["id_media"]);
            LienMedia = Convert.ToString(user["lien_media"]);
            Type = Convert.ToString(user["type"]);
            Description = Convert.ToString(user["description_media"]);
            Valide = Convert.ToBoolean(user["valide"]);
         }
        public MediaModel()
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
