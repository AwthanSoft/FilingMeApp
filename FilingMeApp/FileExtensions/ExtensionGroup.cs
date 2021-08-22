using FilingMeApp.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilingMeApp.FileExtensions
{
    //      "| JPEG(*.JPG, *.JPEG, *.jpg, *.jpeg) | *.JPG; *.JPEG; *.jpg; *.jpeg" +
    public class ExtensionGroup
    {
        public readonly FileTypeEnum FileType;
        public readonly string GroupName;
        FileExtension[] _Extensions;
        public FileExtension[] Extensions=> _Extensions;
        public ExtensionGroup(FileTypeEnum FileType, string GroupName,params string[] Extensions)
        {
            this.GroupName = GroupName;
            this.FileType = FileType;
            if (Extensions == null || Extensions.Length == 0)
            {
                throw new ArgumentNullException();
            }

            List<FileExtension> exts_list = new List<FileExtension>();
            foreach(var ext in Extensions)
            {
                exts_list.Add(new FileExtension(ext, FileType, GroupName));
            }
            _Extensions = exts_list.ToArray();
        }


        /// <summary>
        //  return as this values filter
        /// <returns>"| JPEG(*.JPG, *.JPEG, *.jpg, *.jpeg) | *.JPG; *.JPEG; *.jpg; *.jpeg"</returns>
        public string AsFilterPart()
        {
            return ExtensionsHelper.ExtensionGroupToPartFilter(this);
        }
    
    }
}
