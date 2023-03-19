using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsmhToolChest.Libraries
{
    internal class File
    {
        public static void ClearDirectory(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                ClearDirectory(subDirectory.FullName);
                subDirectory.Attributes = FileAttributes.Normal;
                subDirectory.Delete();
            }

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Attributes = FileAttributes.Normal;
                file.Delete();
            }
        }
    }
}
