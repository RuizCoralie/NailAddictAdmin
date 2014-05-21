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
    /// Logique d'interaction pour Media.xaml
    /// </summary>
    public partial class Media : UserControl, INotifyPropertyChanged
    {
        
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
        public Media(List<MediaModel> media, bool valide)
        {
            InitializeComponent();
            MediaCollection = new ObservableCollection<MediaModel>(media);
            VisibilityValide = valide;
        }
        #endregion

        #region Fields
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
            //Requête supp vernis
        }

        private void btn_Valide_Click(object sender, RoutedEventArgs e)
        {
            //Requête valide vernis
        }
    }
}
