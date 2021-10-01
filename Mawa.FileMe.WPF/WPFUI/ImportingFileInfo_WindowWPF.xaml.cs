using Mawa.FileMe.Controls;
using Mawa.FileMe.WPF.Controls;
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
using System.Windows.Shapes;

namespace Mawa.FileMe.WPF
{
    /// <summary>
    /// Interaction logic for ImportingFileInfo_WindowWPF.xaml
    /// </summary>
    public partial class ImportingFileInfo_WindowWPF : Window
    {
        ImportingFileCtrl _importingFileCtrl;
        public ImportingFileCtrlCore importingFileCtrl
        {
            get => _importingFileCtrl;
            private set
            {
                _importingFileCtrl = value as ImportingFileCtrl;
                DataContext = value;

                this.importFile_UserControlWPF.importingFileCtrl = value;
                this.filingInfo_UserControlWPF.FileInfoCtrl = value.FileInfoCtrl;
            }
        }
        public ImportingFileInfo_WindowWPF()
        {
            InitializeComponent();
            importingFileCtrl = new ImportingFileCtrl();
        }

        public ImportingFileInfo_WindowWPF(ImportingFileCtrlCore ImportingFileCtrl)
        {
            InitializeComponent();
            this.importingFileCtrl = ImportingFileCtrl;
        }
   
    

        private void Done_btn_Click(object sender, RoutedEventArgs e)
        {
            if(importingFileCtrl.Done())
            {
                this.Close();
            }
            else
            {
                throw new Exception("there is no File!");
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            importingFileCtrl.Cancel();
            this.Close();
        }
    }
}
