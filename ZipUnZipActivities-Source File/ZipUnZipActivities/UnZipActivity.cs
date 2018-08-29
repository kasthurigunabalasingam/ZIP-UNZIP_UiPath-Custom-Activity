using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using Ionic.Zip;
using System.IO;

namespace ZipUnZipActivities
{
    public class UnZipActivity : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Zip File")]
        [Description("The full path of ZipFile")]
        public InArgument<string> ZipFile { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Extract Folder Path")]
        [Description("The full path of output folder location")]
        public InArgument<string> ExtractLocation { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Password")]
        [Description("Password")]
        public InArgument<string> Password { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var SourceFilePath = ZipFile.Get(context);
            var DestinationFolderPath = ExtractLocation.Get(context);
            var Password_Val = Password.Get(context);

            using (ZipFile zip = new ZipFile(SourceFilePath))
            {
                zip.Password = Password_Val.ToString();
                zip.ExtractAll(DestinationFolderPath);
            }
        }
    }
}
