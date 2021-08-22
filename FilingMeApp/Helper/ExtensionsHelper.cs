using FilingMeApp.FileExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FilingMeApp.Helper
{
    public static class ExtensionsHelper
    {
        //public const string AllFilesFilter_Default = "All Files|*.*";
        public const string AllFilesFilter_Default = "All Files(*.*) | *.*";

        /// <summary>
        /// JPEG(*.JPG, *.JPEG, *.jpg, *.jpeg) | *.JPG; *.JPEG; *.jpg; *.jpeg"
        /// </summary>
        /// <param name="extensions"></param>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        public static string ExtensionsToPartFilter(string[] extensions, string GroupName)
        {
            string fltr = string.Empty;
            //Name
            fltr += $"{GroupName}(";
            //fltr += $"| {GroupName}(";
            for (int i = 0; i < extensions.Length - 1; i++)
            {
                fltr += $"*.{extensions[i]}, ";
            }
            fltr += $"*.{extensions[extensions.Length - 1]}";
            fltr += ")";

            //Filter
            fltr += " | ";
            for (int i = 0; i < extensions.Length - 1; i++)
            {
                fltr += $"*.{extensions[i]}; ";
            }
            fltr += $"*.{extensions[extensions.Length - 1]}";

            return fltr;
        }

        /// <summary>
        /// Convert to part of filter
        /// </summary>
        /// <param name="FileExtensions">List Of FileXtensions</param>
        /// <param name="GroupName"></param>
        /// <returns>| JPEG(*.JPG, *.JPEG, *.jpg, *.jpeg) | *.JPG; *.JPEG; *.jpg; *.jpeg"</returns>
        public static string ExtensionsToPartFilter(FileExtension[] FileExtensions, string GroupName)
        {
            List<string> extensions = new List<string>();
            foreach (var ext in FileExtensions)
            {
                extensions.Add(ext.Upper);
                extensions.Add(ext.Lower);
            }
            return ExtensionsToPartFilter(extensions.ToArray(), GroupName);
        }

        /// <summary>
        /// Convert to part of filter
        /// </summary>
        /// <param name="extensionGroup">Send Group that contains list extensions</param>
        /// <returns>| JPEG(*.JPG, *.JPEG, *.jpg, *.jpeg) | *.JPG; *.JPEG; *.jpg; *.jpeg"</returns>
        public static string ExtensionGroupToPartFilter(ExtensionGroup extensionGroup)
        {
            return ExtensionsToPartFilter(extensionGroup.Extensions, extensionGroup.GroupName);
        }

        /// <summary>
        /// this will be as
        /// 
        /// "All Image Files(*.BMP, *.bmp, *.JPG, *.JPEG, *.jpg, *.jpeg, *.PNG, *.png, *.GIF, *.gif, *.tif, *.tiff, *.ico, *.ICO) | *.BMP; *.bmp; *.JPG; *.JPEG; *.jpg; *.jpeg; *.PNG; *.png; *.GIF; *.gif; *.tif; *.tiff; *.ico; *.ICO" +
        ///        "| PNG(*.PNG, *.png) | *.PNG; *.png" 
        ///        "| JPEG(*.JPG, *.JPEG, *.jpg, *.jpeg) | *.JPG; *.JPEG; *.jpg; *.jpeg" 
        ///        "| Bitmap(*.BMP,*.bmp) | *.BMP; *.bmp"
        ///        "| GIF(*.GIF, *.gif) | *.GIF; *.gif" 
        ///        "|TIF(*.tif, *.tiff) | *.tif; *.tiff" 
        ///        "| ICO(*.ico, *.ICO) | *.ico; *.ICO";
        /// </summary>
        /// <param name="FileType"></param>
        /// <param name="ExtensionGroups"></param>
        /// <param name="incloudeAllFileFilter"></param>
        /// <returns></returns>
        public static string GeneralFileTypeToFilter(FileTypeEnum FileType, ExtensionGroup[] ExtensionGroups, bool IncludeAllFileFilterPart = true)
        {
            string fltr = string.Empty;
            if(IncludeAllFileFilterPart)
            {
                fltr += AllFilesFilter_Default;
                fltr += "| ";
            }

            //AllExtensions
            {
                var extensions_list = new List<string>();
                foreach(var exGroup in ExtensionGroups)
                {
                    foreach(var ext in exGroup.Extensions)
                    {
                        extensions_list.Add(ext.Upper);
                        extensions_list.Add(ext.Lower);
                    }
                }
                //RemoveRepeates
                extensions_list.Distinct();
                fltr += ExtensionsToPartFilter(extensions_list.ToArray(), $"All {FileType.ToString()} Files");
            }
            foreach (var exGroup in ExtensionGroups)
            {
                fltr += " | ";
                fltr += ExtensionGroupToPartFilter(exGroup);
            }
            return fltr;
        }
    }
}
