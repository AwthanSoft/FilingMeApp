using Mawa.FileMe.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mawa.FileMe.WPF.Controls
{
    class ImportingFileCtrl : ImportingFileCtrlCore
    {
        public ImportingFileCtrl():base()
        {

        }
        public override void ImportFile_Dialog()
        {

            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            //me
            {
                dlg.Title = "Browse Files";
                //dlg.InitialDirectory = @"C:\Users\ALI\Desktop";


                dlg.FileName = "";
                dlg.Filter = GeneralFilter;
                /*
                ImportFile_openFileDialog1.FilterIndex = FilterIndex;



                ImportFile_openFileDialog1.CheckFileExists = true;
                ImportFile_openFileDialog1.CheckPathExists = true;

                ImportFile_openFileDialog1.ReadOnlyChecked = true;
                this.ImportFile_openFileDialog1.Multiselect = false;
                ImportFile_openFileDialog1.ShowReadOnly = true;
                */

            }


            // Set filter for file extension and default file extension 
            //dlg.DefaultExt = ".png";
            //dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                //textBox1.Text = filename;
                Change_Path(filename);
            }
            else
            {
                //_Change_Path("");
                Change_Path(dlg.FileName);
            }



            /*


            ImportFile_openFileDialog1.Title = "Browse Files";



            // openFileDialog1.InitialDirectory = @"C:\Users\ALI\Desktop";

            ImportFile_openFileDialog1.DefaultExt = "all";

            ImportFile_openFileDialog1.FileName = "";
            ImportFile_openFileDialog1.Filter = GeneralFilter;
            ImportFile_openFileDialog1.FilterIndex = FilterIndex;



            ImportFile_openFileDialog1.CheckFileExists = true;
            ImportFile_openFileDialog1.CheckPathExists = true;

            ImportFile_openFileDialog1.ReadOnlyChecked = true;
            this.ImportFile_openFileDialog1.Multiselect = false;
            ImportFile_openFileDialog1.ShowReadOnly = true;

            ImportFile_openFileDialog1.ShowDialog();



            ImportPhototextBox.Text = ImportFile_openFileDialog1.FileName;

            /*
            foreach (String file in ImportFile_openFileDialog1.FileNames)
            {
                ImportPhototextBox.Text = file;
                //MessageBox.Show(file);
                if (ImportPhototextBox.Text != null)
                {
                    try
                    {
                        ImportPhototextBox.BackColor = Color.White;
                        ImportPhototextBox.Text = file;
                        Photo = new Photo_Class(ImportPhototextBox.Text);

                        //   FileInfo fil = new FileInfo(file);
                    }
                    catch
                    {
                        ImportPhototextBox.BackColor = Color.Red;
                        Photo = null;
                    }
                }

                IsChanged = true;
             

            }*/
        }
    }
}
