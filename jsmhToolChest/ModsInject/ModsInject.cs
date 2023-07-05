using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jsmhToolChest.ModsInject
{
    internal class ModsInject
    {
        public static string ModsFolder = Config.Config_folder + "\\InjectMods";
        public static void Reload()
        {
            if (Directory.Exists(ModsFolder))
            {
                Program.mainWindow.listView2.Items.Clear();
                foreach (FileInfo file in new DirectoryInfo(ModsFolder).GetFiles("*.jar"))
                {
                    Program.mainWindow.listView2.Items.Add(new ListViewItem(new String[] { Path.GetFileNameWithoutExtension(file.Name), "启用" }));
                }
                foreach (FileInfo file in new DirectoryInfo(ModsFolder).GetFiles("*.dis"))
                {
                    Program.mainWindow.listView2.Items.Add(new ListViewItem(new String[] { Path.GetFileNameWithoutExtension(file.Name), "禁用" }));
                }
            }
        }

    }
}
