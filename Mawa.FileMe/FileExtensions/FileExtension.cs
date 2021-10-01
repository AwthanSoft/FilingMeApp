using System;
using System.Collections.Generic;
using System.Text;

namespace Mawa.FileMe.FileExtensions
{
    public class FileExtension
    {
        public readonly string ExtensionGroupName;

        readonly string Extension;
        public readonly FileTypeEnum FileType;
        public string Lower => Extension.ToLower();
        public string Upper => Extension.ToUpper();
        public string Original => Extension;
        public FileExtension(string Extension, FileTypeEnum FileType , string ExtensionGroupName = "")
        {
            this.Extension = Extension;
            this.FileType = FileType;
            this.ExtensionGroupName = ExtensionGroupName;
        }
    }
}
