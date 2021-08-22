using System;
using System.Collections.Generic;
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

namespace FilingMeApp.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TestImportFile01_Button_Click(object sender, RoutedEventArgs e)
        {
            var frm = new FilingMeApp.WPF.ImportingFileInfo_WindowWPF();
            frm.ShowDialog();
        }

        private void TestImportFileByType_Button_Click(object sender, RoutedEventArgs e)
        {
            var frm = new FilingMeApp.WPF.ImportingFileInfo_WindowWPF();
            frm.importingFileCtrl.SetGeneralFilter(FileTypeEnum.Image);
            frm.ShowDialog();
        }
    }
}
