using NailAddictAdmin.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NailAddictAdmin.UserControls.Apercu
{
    /// <summary>
    /// Logique d'interaction pour ApercuVernis.xaml
    /// </summary>
    public partial class ApercuVernis : UserControl, INotifyPropertyChanged
    {
        public ApercuVernis()
        {
            InitializeComponent();
        }

        public ApercuVernis(VernisModel vernis)
        {
            InitializeComponent();
            Vernis = vernis;
        }

        private VernisModel _Vernis;
        public VernisModel Vernis
        {
            get { return _Vernis; }
            set
            {
                _Vernis = value;
                NotifyPropertyChanged("Vernis");
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
    }
}
