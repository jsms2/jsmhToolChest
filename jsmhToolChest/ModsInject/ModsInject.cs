using jsmhToolChest.ClientLaunch;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jsmhToolChest.ModsInject
{
    internal class ModsInjectMain
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

        public static void SwitchMod(int index)
        {

            string name = Program.mainWindow.listView2.Items[index].SubItems[0].Text;
            string state = Program.mainWindow.listView2.Items[index].SubItems[1].Text;
            string finalstate = null;
            string finalname = null;
            switch (state)
            {
                case "启用":
                    finalname = ModsInjectMain.ModsFolder + "\\" + name + ".dis";
                    finalstate = "禁用";
                    name = ModsInjectMain.ModsFolder + "\\" + Program.mainWindow.listView2.Items[index].SubItems[0].Text + ".jar";
                    break;
                case "禁用":
                    finalname = ModsInjectMain.ModsFolder + "\\" + name + ".jar";
                    finalstate = "启用";
                    name = ModsInjectMain.ModsFolder + "\\" + Program.mainWindow.listView2.Items[index].SubItems[0].Text + ".dis";
                    break;
                default:
                    Program.mainWindow.ShowError("程序在处理模组名称时遇到的无法处理的字符串" + state);
                    break;
            }
            if (File.Exists(finalname))
            {
                MessageBox.Show($"程序无法启用/禁用该模组，因为文件{finalname}已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                File.Move(name, finalname);
                Program.mainWindow.listView2.Items[index].SubItems[1].Text = finalstate;
            }
            catch (Exception e)
            {
                Program.mainWindow.ShowError("程序在启用/禁用模组时出现错误: " + e.Message);
            }
        }

        public static void WriteMods()
        {
            try
            {
                MD5 md5 = MD5.Create();
                foreach (string filepath in Directory.GetFiles(ModsFolder, "*.jar"))
                {

                    try
                    {
                        FileInfo file = new FileInfo(filepath);
                        string filename = file.Name;
                        string newfilename = "😅" + Libraries.String.ByteArrayToHexString(md5.ComputeHash(Encoding.UTF8.GetBytes(filename))) + "😅.jar";
                        file.CopyTo(Program.mainWindow.regedit.GetGamePatch() + "\\Game\\.minecraft\\mods\\" + newfilename);
                        Program.mainWindow.LogTime();
                        Program.mainWindow.SuccessLogs($"模组{filename}已注入");
                    }
                    catch (Exception e)
                    {
                        Program.mainWindow.LogTime();
                        Program.mainWindow.ErrorLogs($"在注入单个模组{filepath}时发生错误: {e.Message}");
                    }


                }
            } catch (Exception e)
            {
                Program.mainWindow.LogTime();
                Program.mainWindow.ErrorLogs($"在注入模组时发生错误: {e.Message}");
            }

            
        }
    }

    
}
