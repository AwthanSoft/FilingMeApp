using FilingMeApp.FileExtensions;
using FilingMeApp.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilingMeApp.Filters
{
    public static class GeneralFileFilters
    {
        public static string AllFilesFilter_Default => ExtensionsHelper.AllFilesFilter_Default;
        public static string ImageFilter(bool IncludeAllFileFilterPart = true)
        {
            return GeneralImageExtensions.tempInstance.GetFilter(IncludeAllFileFilterPart);
        }
        public static string LiteDatabaseFilter(bool IncludeAllFileFilterPart = true)
        {
            return GeneralLiteDatabaseExtensions.tempInstance.GetFilter(IncludeAllFileFilterPart);
        }

        public static string GetFilterByFileType(FileTypeEnum FileType,bool IncludeAllFileFilterPart = true)
        {
            switch(FileType)
            {
                case FileTypeEnum.Image:
                    {
                        return ImageFilter(IncludeAllFileFilterPart);
                    }
                case FileTypeEnum.LiteDatabase:
                    {
                        return LiteDatabaseFilter(IncludeAllFileFilterPart);
                    }
                default:
                    {
                        throw new ArgumentException("Unknown Type");
                    }
            }
        }
        
    }
}
