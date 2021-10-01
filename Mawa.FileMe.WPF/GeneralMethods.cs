using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawa.FileMe.WPF
{
    public static class GeneralMethods
    {
        public static string OpenFile(FileTypeEnum FileType = FileTypeEnum.Default)
        {
            var frm = new ImportingFileInfo_WindowWPF();
            switch(FileType)
            {
                case FileTypeEnum.Default:
                    {
                        break;
                    }
                case FileTypeEnum.Image:
                    {
                        frm.importingFileCtrl.SetGeneralFilter(FileType);
                        break;
                    }
                case FileTypeEnum.LiteDatabase:
                    {
                        frm.importingFileCtrl.SetGeneralFilter(FileType);
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException();
                    }
            }
            frm.ShowDialog();
            if(frm.importingFileCtrl.isDone)
            {
                return frm.importingFileCtrl.FileInfoCtrl.FilePath;
            }
            else
            {
                //If Is Cancel || ErrorSave
            }
            return null;
        }
    }
}
