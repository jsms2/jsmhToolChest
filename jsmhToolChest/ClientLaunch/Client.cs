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
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Version;
using SharpCompress.Common;
using System.Threading;

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
                if (Directory.Exists(folder))
                {
                    Directory.Delete(folder, true);
                }
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



    internal class Launch
    {
        public static Process ClientProcess;
        public static Thread ClientTestThreadObj;

        public static void ClientTestThread()
        {
            try
            {
                ClientProcess.WaitForExit();
                ClientProcess = null;

                Program.mainWindow.LogTime();
                Program.mainWindow.CustomLogs("客户端已结束");

            } catch (Exception e)
            {
                Program.mainWindow.LogTime();
                Program.mainWindow.ErrorLogs("客户端检测错误,错误信息:" + e.Message);
            }
            Action action = () =>
            {
                Program.mainWindow.button12.Text = "启动客户端";
            };
            Program.mainWindow.Invoke(action);
            

        }

        public static async void LaunchGame()
        {
            try
            {
                Program.mainWindow.button12.Enabled = false;
                int memory;
                if (!int.TryParse(Program.mainWindow.textBox2.Text, out memory))
                {
                    Program.mainWindow.LogTime();
                    Program.mainWindow.ErrorLogs($"客户端启动失败，无法将{Program.mainWindow.textBox2.Text}转换为int形式");
                    return;
                }
                int Width;
                if (!int.TryParse(Program.mainWindow.textBox4.Text, out Width))
                {
                    Program.mainWindow.LogTime();
                    Program.mainWindow.ErrorLogs($"客户端启动失败，无法将{Program.mainWindow.textBox4.Text}转换为int形式");
                    return;
                }
                int Height;
                if (!int.TryParse(Program.mainWindow.textBox5.Text, out Height))
                {
                    Program.mainWindow.LogTime();
                    Program.mainWindow.ErrorLogs($"客户端启动失败，无法将{Program.mainWindow.textBox5.Text}转换为int形式");
                    return;
                }
                string java = Program.mainWindow.textBox1.Text;
                if (!File.Exists(java))
                {
                    Program.mainWindow.LogTime();
                    Program.mainWindow.ErrorLogs($"客户端启动失败，Java{java}不存在");
                    return;
                }
                if (Program.mainWindow.comboBox1.SelectedIndex < 0)
                {
                    Program.mainWindow.LogTime();
                    Program.mainWindow.ErrorLogs($"客户端启动失败，请选择一个游戏版本");
                    return;
                }

                var path = new MinecraftPath(ClientInformation.ClientPath);
                var launcher = new CMLauncher(path);


                var launchOption = new MLaunchOption
                {
                    MaximumRamMb = memory,
                    Session = MSession.GetOfflineSession(Program.mainWindow.textBox_name.Text.Equals("") ? "None" : Program.mainWindow.textBox_name.Text),
                    JavaPath = java,
                    Path = path,
                    ScreenWidth = Width,
                    ScreenHeight = Height,
                };
                launcher.ProgressChanged += (s, e1) =>
                {
                    Debug.Print(e1.ProgressPercentage.ToString());
                };
                
                ClientProcess = await launcher.CreateProcessAsync(Program.mainWindow.comboBox1.Text, launchOption,false);
                WriteAuthlib();
                ClientProcess.Start();
                Program.mainWindow.LogTime();
                Program.mainWindow.SuccessLogs($"客户端成功启动 PID:{ClientProcess.Id}");
                ClientTestThreadObj = new Thread(ClientTestThread);
                ClientTestThreadObj.Start();
                Program.mainWindow.button12.Text = "结束客户端";
                Program.mainWindow.button12.Enabled = true;
            } catch (Exception e)
            {
                Program.mainWindow.LogTime();
                Program.mainWindow.ErrorLogs($"客户端启动错误，错误信息: " + e.Message);
                return;
            }
            
        }

        public static void WriteAuthlib()
        {
            try
            {
                byte[] au = new byte[0];
                if (Program.mainWindow.radioButton1.Checked)
                {
                    au = Resource1.CL8Authlib;
                }
                string file_1521 = ClientInformation.ClientPath + "\\libraries\\com\\mojang\\authlib\\1.5.21\\authlib-1.5.21.jar";
                string folder_1521 = ClientInformation.ClientPath + "\\libraries\\com\\mojang\\authlib\\1.5.21";
                string file_1525 = ClientInformation.ClientPath + "\\libraries\\com\\mojang\\authlib\\1.5.25\\authlib-1.5.25.jar";
                string folder_1525 = ClientInformation.ClientPath + "\\libraries\\com\\mojang\\authlib\\1.5.25";
                if (File.Exists(file_1521))
                {
                    if ((File.GetAttributes(file_1521) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        File.SetAttributes(file_1521, FileAttributes.Normal);
                    }
                    File.Delete(file_1521);
                }
                if (File.Exists(file_1525))
                {
                    if ((File.GetAttributes(file_1525) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        File.SetAttributes(file_1525, FileAttributes.Normal);
                    }
                    File.Delete(file_1525);
                }
                if (Directory.Exists(folder_1521))
                {
                    Directory.Delete(folder_1521);
                }
                if (Directory.Exists(folder_1525))
                {
                    Directory.Delete(folder_1525);
                }
                Directory.CreateDirectory(folder_1521);
                Directory.CreateDirectory(folder_1525);
                File.WriteAllBytes(file_1521, au);
                File.WriteAllBytes(file_1525, au);
                File.SetAttributes(file_1521, File.GetAttributes(file_1521) | FileAttributes.ReadOnly);
                File.SetAttributes(file_1525, File.GetAttributes(file_1525) | FileAttributes.ReadOnly);
                Program.mainWindow.LogTime();
                Program.mainWindow.SuccessLogs("Authlib替换成功");
            }
            catch (Exception e)
            {
                Program.mainWindow.LogTime();
                Program.mainWindow.ErrorLogs("Authlib替换出错,错误信息: " + e.Message);
            }
            
        }
    }
}
