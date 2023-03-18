using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace jsmhToolChest.ClientLaunch
{
    internal class ClientInformation
    {
        public static string ClientPath;
        public static string ClientName;
        public static bool SelectedClient = false;

        public static void SelectEvent()
        {
            try
            {
                Config.Config_json["Window"]["MainWindow"]["Client"]["SelectClientInfo"]["name"] = ClientName;
                Config.Config_json["Window"]["MainWindow"]["Client"]["SelectClientInfo"]["path"] = ClientPath;
                Config.Save();
            }
            catch (Exception err)
            {
                Program.mainWindow.ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }

            Program.mainWindow.tabControl2.SelectedIndex = 1;
            Program.mainWindow.tabControl2.TabPages[1].Text = $"客户端设置 - 当前选择:{ClientName}";

            DirectoryInfo directory = new DirectoryInfo(ClientPath);
            if (directory.GetFileSystemInfos().Length == 0)
            {
                ClientDownload.Start(ClientPath);
            }
            Reload();
        }

        public static void Reload()
        {
            if (Directory.Exists(ClientPath))
            {
                //Mods
                if (Directory.Exists(ClientPath + "\\mods"))
                {
                    Program.mainWindow.listView1.Items.Clear();
                    foreach (FileInfo file in new DirectoryInfo(ClientPath + "\\mods").GetFiles("*.jar"))
                    {
                        Program.mainWindow.listView1.Items.Add(new ListViewItem(new String[] { Path.GetFileNameWithoutExtension(file.Name), "启用" }));
                    }
                    foreach (FileInfo file in new DirectoryInfo(ClientPath + "\\mods").GetFiles("*.dis"))
                    {
                        Program.mainWindow.listView1.Items.Add(new ListViewItem(new String[] { Path.GetFileNameWithoutExtension(file.Name), "禁用" }));
                    }
                }


                //Client
                if (Directory.Exists(ClientPath + "\\versions"))
                {
                    Program.mainWindow.comboBox1.Items.Clear();
                    foreach (DirectoryInfo file in new DirectoryInfo(ClientPath + "\\versions").GetDirectories())
                    {
                        Program.mainWindow.comboBox1.Items.Add(file.Name);
                    }
                    if (File.Exists(ClientPath + "\\versions\\index.jsmhconfig"))
                    {
                        try
                        {
                            string text = File.ReadAllText(ClientPath + "\\versions\\index.jsmhconfig");
                            int index = Convert.ToInt32(text);
                            if (index >= 0 || index < Program.mainWindow.comboBox1.Items.Count)
                            {
                                Program.mainWindow.comboBox1.SelectedIndex = index;
                            }
                        }
                        catch (Exception) { }


                    }
                }

            }
        }

    }


    internal class Mod
    {
        public static void SwitchMod(int index)
        {
            ListView listview = Program.mainWindow.listView1;
            string name = listview.Items[index].SubItems[0].Text;
            string state = listview.Items[index].SubItems[1].Text;
            string finalstate = null;
            string finalname = null;
            switch (state)
            {
                case "启用":
                    finalname = ClientInformation.ClientPath + "\\mods\\" + name + ".dis";
                    finalstate = "禁用";
                    name = ClientInformation.ClientPath + "\\mods\\" + listview.Items[index].SubItems[0].Text + ".jar";
                    break;
                case "禁用":
                    finalname = ClientInformation.ClientPath + "\\mods\\" + name + ".jar";
                    finalstate = "启用";
                    name = ClientInformation.ClientPath + "\\mods\\" + listview.Items[index].SubItems[0].Text + ".dis";
                    break ;
                default:
                    Program.mainWindow.ShowError("程序在处理模组名称时遇到的无法处理的字符串" + state);
                    break ;
            }
            if (File.Exists(finalname))
            {
                MessageBox.Show($"程序无法启用/禁用该模组，因为文件{finalname}已存在","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            try
            {
                File.Move(name, finalname);
                listview.Items[index].SubItems[1].Text = finalstate;
            }
            catch (Exception e)
            {
                Program.mainWindow.ShowError("程序在启用/禁用模组时出现错误: " + e.Message);
            }
        }
    }


    internal class ClientList
    {
        public static void ReloadClientList()
        {
            Program.mainWindow.ClientListView.Items.Clear();

            foreach(JToken jtokenobj in Config.Config_json["Window"]["MainWindow"]["Client"]["ClientList"])
            {
                
                Program.mainWindow.ClientListView.Items.Add(new ListViewItem(new String[] { (string)jtokenobj["name"], (string)jtokenobj["path"] }));
                
            }


        }

        public static void AddClient(string name,string folder)
        {
            JArray clientList = (JArray)Config.Config_json["Window"]["MainWindow"]["Client"]["ClientList"];
            clientList.Add(new JObject(
                    new JProperty("name", name),
                    new JProperty("path", folder)
                    ));

            Config.Save();
            
        }

        public static void DeleteClient(int index,string selectname,string selectpath)
        {
            JArray clientList = (JArray)Config.Config_json["Window"]["MainWindow"]["Client"]["ClientList"];
            clientList.RemoveAt(index);

            string name = "",path = "";
            if (((JObject)Config.Config_json["Window"]["MainWindow"]["Client"]["SelectClientInfo"]).ContainsKey("name"))
            {
                name = (string)Config.Config_json["Window"]["MainWindow"]["Client"]["SelectClientInfo"]["name"];
            }
            if (((JObject)Config.Config_json["Window"]["MainWindow"]["Client"]["SelectClientInfo"]).ContainsKey("path"))
            {
                path = (string)Config.Config_json["Window"]["MainWindow"]["Client"]["SelectClientInfo"]["path"];
            }
            if (name.Equals(selectname) || path.Equals(selectpath))
            {
                Config.Config_json["Window"]["MainWindow"]["Client"]["SelectClientInfo"]["name"] = "";
                Config.Config_json["Window"]["MainWindow"]["Client"]["SelectClientInfo"]["path"] = "";
            }
            Config.Save();
        }

    }


    internal class ClientDownload
    {
        public static async void Start(string folder)
        {
            try
            {
                Directory.Delete(folder, true);
                Directory.CreateDirectory(folder);

                WebClient client = new WebClient();
                string url = client.DownloadString(Resource1.ServerURL + "ClientDownloadPath.txt");

                Program.mainWindow.Enabled = false;
                await Download.DownloadUtil.StartDownloadAsync(url, folder + "\\Client.zip");
                await UnCompress.UnCompressUtil.StartUnCompressAsync(folder + "\\Client.zip", folder);
                MessageBox.Show("客户端下载成功", "成功");
                Program.mainWindow.Enabled = true;
            }
            catch (Exception e)
            {

                MessageBox.Show("在下载客户端时遇到错误: " + e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
