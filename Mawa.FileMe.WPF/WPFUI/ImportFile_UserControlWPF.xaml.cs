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
    /// Interaction logic for ImportFile_UserControlWPF.xaml
    /// </summary>
    public partial class ImportFile_UserControlWPF : UserControl
    {
        ImportingFileCtrlCore _importingFileCtrl;
        public ImportingFileCtrlCore importingFileCtrl
        {
            get => _importingFileCtrl;
            set
            {
                _importingFileCtrl = value;
                this.DataContext = value;

                _importingFileCtrl.FileInfoCtrl.PathChanged += FileInfoCtrl_PathChanged;
                RefreshInfo();
            }
        }

        public ImportFile_UserControlWPF()
        {
            InitializeComponent();
        }

        private void FileInfoCtrl_PathChanged(object sender, string e)
        {
            RefreshInfo();
        }

        private void RefreshInfo()
        {
            if(importingFileCtrl.FileInfoCtrl.Exist)
            {
                Staue_Grid.Background = Brushes.LightGreen;
            }
            else
            {
                Staue_Grid.Background = Brushes.Red;
            }
        }
        private void Import_btn_Click(object sender, RoutedEventArgs e)
        {
            importingFileCtrl.ImportFile_Dialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            importingFileCtrl.Change_Path((sender as TextBox).Text);
        }
    }
}
