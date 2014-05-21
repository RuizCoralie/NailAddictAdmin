using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace NailAddictAdmin
{
    /// <summary>
    /// Logique d'interaction pour Apercu.xaml
    /// </summary>
    public partial class ApercuWindows : Window, INotifyPropertyChanged
    {
        public ApercuWindows()
        {
            InitializeComponent();
        }

        public ApercuWindows(UserControl uc)
        {
            InitializeComponent();
            Uc_Apercu = uc;
        }

        private UserControl _Uc_Apercu;
        public UserControl Uc_Apercu
        {
            get { return _Uc_Apercu; }
            set
            {
                _Uc_Apercu = value;
                NotifyPropertyChanged("Uc_Apercu");
            }
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

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
