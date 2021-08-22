using FilingMeApp.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilingMeApp.FileExtensions
{
    public class GeneralImageExtensions : GeneralFileExtensions
    {
        public static readonly ExtensionGroup PNG = new
            ExtensionGroup(FileTypeEnum.Image, nameof(PNG), "PNG");

        public static readonly ExtensionGroup JPEG = new
            ExtensionGroup(FileTypeEnum.Image, nameof(JPEG), "JPEG", "JPG");

        public static readonly ExtensionGroup Bitmap = new
            ExtensionGroup(FileTypeEnum.Image, nameof(Bitmap), "BMP");

        public static readonly ExtensionGroup GIF = new
            ExtensionGroup(FileTypeEnum.Image, nameof(GIF), "GIF");

        public static readonly ExtensionGroup TIF = new
            ExtensionGroup(FileTypeEnum.Image, nameof(TIF), "TIF");
      
        public static readonly ExtensionGroup ICO = new
            ExtensionGroup(FileTypeEnum.Image, nameof(ICO), "ICO");

        internal static readonly GeneralFileExtensions tempInstance = new GeneralImageExtensions();

       

        private GeneralImageExtensions() : base(
            FileTypeEnum.Image, new ExtensionGroup[] {
                PNG,
                JPEG,
                Bitmap,
                GIF,
                TIF,
                ICO
            })
        {

        }


    }
}
