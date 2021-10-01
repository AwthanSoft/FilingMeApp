using Mawa.FileMe.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mawa.FileMe.WPF
{
    /// <summary>
    /// Interaction logic for FilingInfo_UserControlWPF.xaml
    /// </summary>
    public partial class FilingInfo_UserControlWPF : UserControl
    {
        LocalFileInfoCtrl _FileInfoCtrl;
        public LocalFileInfoCtrl FileInfoCtrl
        {
            get => _FileInfoCtrl;
            set
            {
                _FileInfoCtrl = value;
                this.DataContext = value;

                _FileInfoCtrl.PathChanged += _FileInfoCtrl_PathChanged;
                RefreshInfo();
            }
        }
        public FilingInfo_UserControlWPF()
        {
            InitializeComponent();
        }

        private void _FileInfoCtrl_PathChanged(object sender, string e)
        {
            RefreshInfo();
        }
     
        private void RefreshInfo()
        {
            if (FileInfoCtrl.Exist)
            {
                Staue_Grid.Background = Brushes.WhiteSmoke;
            }
            else
            {
                Staue_Grid.Background = Brushes.Red;
            }
        }
    }
}
