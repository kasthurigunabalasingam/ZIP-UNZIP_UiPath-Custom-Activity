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
    public class ZipActivity : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Folder Path")]
        [Description("The full path of selected folder")]
        public InArgument<string> FolderPath { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Zipped Path")]
        [Description("The full path of output zip file")]
        public InArgument<string> ZippedPath { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Password")]
        [Description("Password")]
        public InArgument<string> Password { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var SourceFilePath = FolderPath.Get(context);
            var DistinationZipPath = ZippedPath.Get(context);
            var Password_Val = Password.Get(context);

            using (ZipFile zip = new ZipFile())
            {
                zip.Password = Password_Val.ToString();
                zip.AddDirectory(SourceFilePath);
                zip.Save(DistinationZipPath);
            }
        }
    }
}

