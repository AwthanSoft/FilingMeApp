using Mawa.FileMe.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mawa.FileMe.FileExtensions
{
    public class GeneralLiteDatabaseExtensions : GeneralFileExtensions
    {
        public static readonly ExtensionGroup SQLITE = new
            ExtensionGroup(FileTypeEnum.LiteDatabase, nameof(SQLITE), "SQLITE");

        public static readonly ExtensionGroup DB = new
            ExtensionGroup(FileTypeEnum.LiteDatabase, nameof(DB), "DB");

        internal static readonly GeneralFileExtensions tempInstance = new GeneralLiteDatabaseExtensions();

        private GeneralLiteDatabaseExtensions() : base(
            FileTypeEnum.LiteDatabase, new ExtensionGroup[] {
                SQLITE,
                DB
            })
        {

        }


    }
}
