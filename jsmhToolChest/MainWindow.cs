using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using jsmhToolChest.Netease;
using Microsoft.VisualBasic;
using System.Net;
using System.Windows.Forms.ComponentModel.Com2Interop;
using jsmhToolChest.ClientLaunch;
using SharpCompress.Common;
using jsmhToolChest.ModsInject;
using System.Threading;

namespace jsmhToolChest
{
    public partial class MainWindow : Form
    {
        public Netease.RegeditRead regedit;
        bool StartBoxButton_isFirstClick = true;
        public static bool InitializationDone = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void StartBox_Click(object sender, EventArgs e)
        {
            if(!WPFLauncher.TestedNeteaseClient)
            {
                StartBox.Enabled = false;
                if (StartBoxButton_isFirstClick)
                {
                    regedit = new Netease.RegeditRead(is4399.Checked);
                    if ("".Equals(regedit.GetInstallPatch()))
                    {
                        MessageBox.Show("你的电脑没有安装对应版本的盒子，请先安装后再使用。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    is4399.Enabled = false;
                    StartBoxButton_isFirstClick = false;
                    StartBox.Text = "重启盒子";
                }
                else
                {
                    Netease.Hook.LocalPortListener.Stop();
                    try
                    {
                        Netease.WPFLauncher.NeteaseClientTestThreadObj.Abort();
                    }
                    catch (Exception) { }
                }
                LogTime();
                CustomLogs("启动盒子，当前为" + (is4399.Checked ? "4399" : "网易") + "盒子模式");
                try
                {
                    await Netease.WPFLauncher.Launch();
                }
                catch (Exception err)
                {
                    LogTime();
                    ErrorLogs("盒子启动失败 详细信息:" + err.Message);
                }
                StartBox.Enabled = true;
            } else
            {
                Process Netease = NeteaseClient.GetNeteaseClientProcess();
                if (Netease != null)
                {
                    Netease.Kill();
                    
                }
            }
            
            
        }
        public void ChangeStartBoxText(string Text)
        {
            Action action = () =>
            {
                StartBox.Text = Text;
            };
            Invoke(action);
            
        }


        public void LogTime()
        {
            Action action = () =>
            {
                LogBox.SelectionColor = Color.Black;
                LogBox.SelectionFont = LogBox.Font;
                LogBox.AppendText("\r\n[" + DateTime.Now.ToString("HH:mm:ss.fff") + "] ");
            };
            Invoke(action);
        }

        public void CustomLogs(string message)
        {
            Action action = () =>
            {
                LogBox.SelectionColor = Color.Black;
                LogBox.SelectionFont = LogBox.Font;
                LogBox.AppendText(message);
            };
            Invoke(action);
        }
        public void ErrorLogs(string message)
        {
            Action action = () =>
            {
                LogBox.SelectionColor = Color.Red;
                LogBox.SelectionFont = LogBox.Font;
                LogBox.AppendText(message);

            };
            Invoke(action);
        }
        public void SuccessLogs(string message)
        {
            Action action = () =>
            {
                LogBox.SelectionColor = Color.Green;
                LogBox.SelectionFont = LogBox.Font;
                LogBox.AppendText(message);

            };
            Invoke(action);
        }
        public void ImportantLogs(string message)
        {
            Action action = () =>
            {
                int start = LogBox.SelectionStart;
                LogBox.SelectionColor = Color.Blue;
                LogBox.SelectionFont = new Font( LogBox.Font,FontStyle.Underline);
                LogBox.AppendText(message);

            };
            Invoke(action);
        }
        public void ShowError(string message)
        {
            MessageBox.Show(Program.mainWindow, message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Process.GetCurrentProcess().Kill();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            bool LatestVersion = VersionCheck.IsLatestVersion();
            if (!LatestVersion)
            {
                MessageBox.Show("当前程序非最新版本，请前往官网或Github下载最新版本。继续使用此版本可能会导致无法使用。\r\nWebside: https://jsmh.red/\r\nQQGuild: https://pd.qq.com/s/b8z1gt7f9\r\nGithub: https://github.com/jsms2/jsmhToolChest","版本验证",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            Config.Init();
            try
            { 
                if (((JObject)Config.Config_json["Window"]["MainWindow"]["MainPage"]).ContainsKey("Is4399"))
                {
                    is4399.Checked = (bool)Config.Config_json["Window"]["MainWindow"]["MainPage"]["Is4399"];
                }
                if (((JObject)Config.Config_json["Window"]["MainWindow"]["Settings"]).ContainsKey("DeleteServerMods"))
                {
                    checkBox1.Checked = (bool)Config.Config_json["Window"]["MainWindow"]["Settings"]["DeleteServerMods"];
                }
                if (((JObject)Config.Config_json["Window"]["MainWindow"]["Settings"]).ContainsKey("ShowSAuthLoginForm"))
                {
                    
                    checkBox2.Checked = (bool)Config.Config_json["Window"]["MainWindow"]["Settings"]["ShowSAuthLoginForm"];
                }
                if (((JObject)Config.Config_json["Window"]["MainWindow"]["MainPage"]).ContainsKey("StartMode"))
                {
                    int StartMode = (int)Config.Config_json["Window"]["MainWindow"]["MainPage"]["StartMode"];
                    switch (StartMode)
                    {
                        case 0:
                            Radio_NOAddons.Checked = true;
                            Radio_Client.Checked = false;
                            Radio_Mods.Checked = false;
                            break;
                        case 1:
                            Radio_NOAddons.Checked = false;
                            Radio_Client.Checked = true;
                            Radio_Mods.Checked = false;
                            break ;
                        case 2:
                            Radio_NOAddons.Checked = false;
                            Radio_Client.Checked = false;
                            Radio_Mods.Checked = true;
                            break ;
                        default:
                            ShowError($"程序在读取配置时遇到了无法处理的值: Window.MainWindow.MainPage.StartMode的值为{StartMode}");
                            break;
                    }

                }
                if (((JObject)Config.Config_json["Window"]["MainWindow"]["Settings"]).ContainsKey("CLMode"))
                {
                    int StartMode = (int)Config.Config_json["Window"]["MainWindow"]["Settings"]["CLMode"];
                    switch (StartMode)
                    {
                        case 0:
                            radioButton1.Checked = true;
                            radioButton2.Checked =false;
                            break;
                        case 1:
                            radioButton2.Checked = true;
                            radioButton1.Checked = false;
                            break;
                        default:
                            ShowError($"程序在读取配置时遇到了无法处理的值: Window.MainWindow.Settings.CLMode的值为{StartMode}");
                            break;
                    }

                }
                string name = "", path = "";
                if (((JObject)Config.Config_json["Window"]["MainWindow"]["Client"]["SelectClientInfo"]).ContainsKey("name"))
                {
                    name = (string)Config.Config_json["Window"]["MainWindow"]["Client"]["SelectClientInfo"]["name"];
                }
                if (((JObject)Config.Config_json["Window"]["MainWindow"]["Client"]["SelectClientInfo"]).ContainsKey("path"))
                {
                    path = (string)Config.Config_json["Window"]["MainWindow"]["Client"]["SelectClientInfo"]["path"];
                }
                if (name != "" || path != "")
                {
                    ClientLaunch.ClientInformation.ClientPath = path;
                    ClientLaunch.ClientInformation.ClientName = name;
                    ClientLaunch.ClientInformation.SelectedClient = true;
                    ClientLaunch.ClientInformation.SelectEvent();
                }

                if (((JObject)Config.Config_json["Window"]["MainWindow"]["Settings"]).ContainsKey("MaxMemory"))
                {
                    textBox2.Text = (string)Config.Config_json["Window"]["MainWindow"]["Settings"]["MaxMemory"];
                }
                if (((JObject)Config.Config_json["Window"]["MainWindow"]["Settings"]).ContainsKey("ClientWidth"))
                {
                    textBox4.Text = (string)Config.Config_json["Window"]["MainWindow"]["Settings"]["ClientWidth"];
                }
                if (((JObject)Config.Config_json["Window"]["MainWindow"]["Settings"]).ContainsKey("ClientHeight"))
                {
                    textBox5.Text = (string)Config.Config_json["Window"]["MainWindow"]["Settings"]["ClientHeight"];
                }
                if (((JObject)Config.Config_json["Window"]["MainWindow"]["Settings"]).ContainsKey("JVMArguments"))
                {
                    textBox3.Text = (string)Config.Config_json["Window"]["MainWindow"]["Settings"]["JVMArguments"];
                }
                if (((JObject)Config.Config_json["Window"]["MainWindow"]["Settings"]).ContainsKey("JavaPath"))
                {
                    textBox1.Text = (string)Config.Config_json["Window"]["MainWindow"]["Settings"]["JavaPath"];
                }
             
            } catch (Exception err)
            {
                ShowError("程序在读取配置时发生错误\r\n错误信息:" + err.Message);
            }
            
            ModsInjectMain.Reload();

            ClientLaunch.ClientList.ReloadClientList();

            LogBox.SelectionColor = Color.Orange;
            LogBox.SelectionFont = new Font(LogBox.Font.Name, 15, FontStyle.Bold);
            LogBox.AppendText("欢迎使用jsmhToolChest");

            Text = "jsmhToolChest " + Resource1.Version;
            if (!LatestVersion) { Text += " (非最新版本)"; }

            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("详细信息");
            menu.Items[0].Click += Menu_ShowInformation_Click;
            menu.Items.Add("删除模组");
            menu.Items[1].Click += Menu_DeleteMod_Click;
            menu.Items.Add("重命名");
            menu.Items[2].Click += Menu_Rename_Click;
            menu.Items.Add("在文件资源管理器中选择");
            menu.Items[3].Click += Menu_Select_Click;
            menu.Items.Add("属性");
            menu.Items[4].Click += Menu_Property_Click;
            menu.Font = new Font("微软雅黑", 12);
            listView1.ContextMenuStrip = menu;

            ContextMenuStrip menu2 = new ContextMenuStrip();
            menu2.Items.Add("详细信息");
            menu2.Items[0].Click += Menu2_ShowInformation_Click;
            menu2.Items.Add("删除模组");
            menu2.Items[1].Click += Menu2_DeleteMod_Click;
            menu2.Items.Add("重命名");
            menu2.Items[2].Click += Menu2_Rename_Click;
            menu2.Items.Add("在文件资源管理器中选择");
            menu2.Items[3].Click += Menu2_Select_Click;
            menu2.Items.Add("属性");
            menu2.Items[4].Click += Menu2_Property_Click;
            menu2.Font = new Font("微软雅黑", 12);
            listView2.ContextMenuStrip = menu2;

            LocalWebServer.Start();
            

            InitializationDone = true;
        }
        private void Menu_ShowInformation_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个模组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string path = ClientLaunch.ClientInformation.ClientPath + "\\mods\\" + listView1.Items[selectedIndex].SubItems[0].Text + (listView1.Items[selectedIndex].SubItems[1].Text.Equals("启用") ? ".jar" : ".dis");
                Mods.ShowModInfomation(path);
                
            }

                
        }

        private void Menu2_ShowInformation_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (listView2.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个模组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string path = ModsInjectMain.ModsFolder + "\\" + listView2.Items[selectedIndex].SubItems[0].Text + (listView2.Items[selectedIndex].SubItems[1].Text.Equals("启用") ? ".jar" : ".dis");
                Mods.ShowModInfomation(path);

            }


        }

        private void Menu_DeleteMod_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个模组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else
            {
                if(MessageBox.Show("你确定吗？该操作不可逆","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string path = ClientLaunch.ClientInformation.ClientPath + "\\mods\\" + listView1.Items[selectedIndex].SubItems[0].Text + (listView1.Items[selectedIndex].SubItems[1].Text.Equals("启用") ? ".jar" : ".dis");
                    try
                    {
                        File.Delete(path);
                        listView1.Items.RemoveAt(selectedIndex);
                    } catch (Exception err)
                    {
                        MessageBox.Show("模组删除出错: " + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Menu2_DeleteMod_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (listView2.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个模组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("你确定吗？该操作不可逆", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string path = ModsInjectMain.ModsFolder + "\\" + listView2.Items[selectedIndex].SubItems[0].Text + (listView2.Items[selectedIndex].SubItems[1].Text.Equals("启用") ? ".jar" : ".dis");
                    try
                    {
                        File.Delete(path);
                        listView2.Items.RemoveAt(selectedIndex);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("模组删除出错: " + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Menu_Rename_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个模组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string path = ClientInformation.ClientPath + "\\mods\\" + listView1.Items[selectedIndex].SubItems[0].Text + (listView1.Items[selectedIndex].SubItems[1].Text.Equals("启用") ? ".jar" : ".dis");
                string filename = Path.GetFileNameWithoutExtension(path);
                string fileentension = Path.GetExtension(path);
                string result = Interaction.InputBox("请输入新名称", "改名 " + filename, filename);
                if (!result.Equals(""))
                {
                    char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
                    if (result.IndexOfAny(invalidFileNameChars) >= 0)
                    {
                        MessageBox.Show("请输入一个有效的文件名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            File.Move(path, ClientInformation.ClientPath + "\\mods\\" + result + fileentension );
                            listView1.Items[selectedIndex].SubItems[0].Text = result;
                        } catch (Exception err)
                        {
                            MessageBox.Show("模组重命名出错: " + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void Menu2_Rename_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (listView2.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个模组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string path = ModsInjectMain.ModsFolder + "\\" + listView2.Items[selectedIndex].SubItems[0].Text + (listView2.Items[selectedIndex].SubItems[1].Text.Equals("启用") ? ".jar" : ".dis");
                string filename = Path.GetFileNameWithoutExtension(path);
                string fileentension = Path.GetExtension(path);
                string result = Interaction.InputBox("请输入新名称", "改名 " + filename, filename);
                if (!result.Equals(""))
                {
                    char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
                    if (result.IndexOfAny(invalidFileNameChars) >= 0)
                    {
                        MessageBox.Show("请输入一个有效的文件名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            File.Move(path, ModsInjectMain.ModsFolder + "\\" + result + fileentension);
                            listView2.Items[selectedIndex].SubItems[0].Text = result;
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("模组重命名出错: " + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void Menu_Select_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个模组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string path = ClientInformation.ClientPath + "\\mods\\" + listView1.Items[selectedIndex].SubItems[0].Text + (listView1.Items[selectedIndex].SubItems[1].Text.Equals("启用") ? ".jar" : ".dis");
                Process.Start("explorer.exe", $"/select,\"{path}\"");
            }
        }

        private void Menu2_Select_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (listView2.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个模组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string path = ModsInjectMain.ModsFolder + "\\" + listView2.Items[selectedIndex].SubItems[0].Text + (listView2.Items[selectedIndex].SubItems[1].Text.Equals("启用") ? ".jar" : ".dis");
                Process.Start("explorer.exe", $"/select,\"{path}\"");
            }
        }

        private void Menu_Property_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个模组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string path = ClientInformation.ClientPath + "\\mods\\" + listView1.Items[selectedIndex].SubItems[0].Text + (listView1.Items[selectedIndex].SubItems[1].Text.Equals("启用") ? ".jar" : ".dis");
                Libraries.File.ShowFileProperties(path);
            }
        }

        private void Menu2_Property_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (listView2.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个模组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string path = ModsInjectMain.ModsFolder + "\\" + listView2.Items[selectedIndex].SubItems[0].Text + (listView2.Items[selectedIndex].SubItems[1].Text.Equals("启用") ? ".jar" : ".dis");
                Libraries.File.ShowFileProperties(path);
            }
        }

        private void is4399_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Config_json["Window"]["MainWindow"]["MainPage"]["Is4399"] = is4399.Checked;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出程序?","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    WPFLauncher.WPFProcess.Kill();
                    Process NeteaseClientProcess = NeteaseClient.GetNeteaseClientProcess();
                    if (NeteaseClientProcess != null) { NeteaseClientProcess.Kill(); }

                }
                catch (Exception) { }
                Process.GetCurrentProcess().Kill();
            }else
            {
                e.Cancel = true;
            }
            
        }
        private void Radio_NOAddons_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Config_json["Window"]["MainWindow"]["MainPage"]["StartMode"] = 0;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }
        private void Radio_Client_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Config_json["Window"]["MainWindow"]["MainPage"]["StartMode"] = 1;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }
        private void Radio_Mods_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Config_json["Window"]["MainWindow"]["MainPage"]["StartMode"] = 2;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Config_json["Window"]["MainWindow"]["Settings"]["CLMode"] = 0;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Config_json["Window"]["MainWindow"]["Settings"]["CLMode"] = 1;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text != "")
            {
                Clipboard.SetText(textBox_name.Text);
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_IP.Text != "")
            {
                Clipboard.SetText(textBox_IP.Text);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://jsmh.red/");
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://pd.qq.com/s/b8z1gt7f9");
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/jsms2/jsmhToolChest");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClientLaunch.AddClientForm form = new ClientLaunch.AddClientForm();
            form.ShowDialog();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < ClientListView.Items.Count; i++)
            {
                if (ClientListView.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个客户端", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                string path = ClientListView.Items[selectedIndex].SubItems[1].Text;
                if (ClientListView.Items[selectedIndex].SubItems[1].Text.Equals(ClientLaunch.ClientInformation.ClientPath) || ClientListView.Items[selectedIndex].SubItems[0].Text.Equals(ClientLaunch.ClientInformation.ClientName))
                {
                    ClientLaunch.ClientInformation.ClientPath = "";
                    ClientLaunch.ClientInformation.ClientName = "";
                    ClientLaunch.ClientInformation.SelectedClient = false;
                    tabControl2.TabPages[1].Text = "客户端设置";
                }


                ClientLaunch.ClientList.DeleteClient(selectedIndex, ClientListView.Items[selectedIndex].SubItems[0].Text, ClientListView.Items[selectedIndex].SubItems[1].Text);
                ClientLaunch.ClientList.ReloadClientList();
                if (MessageBox.Show($"客户端已删除，是否要将客户端本地目录{path}里的内容也一并删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (MessageBox.Show("你确定吗？这是最后一次警告", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        try
                        {
                            Libraries.File.ClearDirectory(path);
                            MessageBox.Show("客户端目录已清空","提示",MessageBoxButtons.OK);

                        } catch(Exception err)
                        {
                            MessageBox.Show("目录清空错误,错误信息: " + err.Message, "提示", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        

                    }
                }

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < ClientListView.Items.Count; i++)
            {
                if (ClientListView.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个客户端", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string folder = ClientListView.Items[selectedIndex].SubItems[1].Text;

                if (!Directory.Exists(folder))
                {
                    MessageBox.Show($"该客户端对应的目录{folder}不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DirectoryInfo directory = new DirectoryInfo(folder);
                if (directory.GetFileSystemInfos().Length != 0)
                {
                    if(MessageBox.Show($"你确认要重新下载客户端吗，如果你点击了确定，那么你选择的目录{folder}将会被清空，该目录下的{directory.GetFileSystemInfos().Length}个文件和目录也会被清空，这可能导致你之前的游戏存档丢失。","警告",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) != DialogResult.OK)
                    {
                        return;
                    }
                    if (MessageBox.Show("这是最后一次警告，点击确定后，你将没有机会反悔。", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    {
                        return;
                    }
                }

                ClientLaunch.ClientDownload.Start(folder);

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < ClientListView.Items.Count; i++)
            {
                if (ClientListView.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个客户端", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ClientLaunch.ClientInformation.ClientPath = ClientListView.Items[selectedIndex].SubItems[1].Text;
                ClientLaunch.ClientInformation.ClientName = ClientListView.Items[selectedIndex].SubItems[0].Text;
                ClientLaunch.ClientInformation.SelectedClient = true;
                ClientLaunch.ClientInformation.SelectEvent();

            }
        }

        private void tabControl2_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                if (!ClientLaunch.ClientInformation.SelectedClient)
                {
                    e.Cancel = true;
                    MessageBox.Show("请先选择一个客户端", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            int selectedIndex = -1;
            for (int i = 0; i < ClientListView.Items.Count; i++)
            {
                if (ClientListView.Items[i].Selected)
                {
                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex == -1)
            {
                MessageBox.Show("请选中一个客户端", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Process.Start("explorer.exe", ClientListView.Items[selectedIndex].SubItems[1].Text);
            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(ClientLaunch.ClientInformation.ClientPath + "\\versions\\index.jsmhconfig", comboBox1.SelectedIndex.ToString());
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientLaunch.ClientInformation.Reload();

        }

    

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left))
            {
                int selectedIndex = -1;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        selectedIndex = i;
                        break;
                    }
                }

                if (selectedIndex != -1)
                {
                    ClientLaunch.Mod.SwitchMod(selectedIndex);
                }
                
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Text.Equals("启动客户端"))
            {
                ClientLaunch.Launch.LaunchGame();
            }
            if (button12.Text.Equals("结束客户端"))
            {
                try
                {
                    ClientLaunch.Launch.ClientProcess.Kill();
                }
                catch
                {

                }
                
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            long input;
            if (long.TryParse(textBox2.Text, out input)){
                if (input > 2147483647)
                {
                    textBox2.Text = "2147483647";
                    return;
                } else if (input < 0)
                {
                    textBox2.Text = "0";
                    return;
                }
            } else
            {
                textBox2.Text = "";
                return;
            }

            try
            {
                Config.Config_json["Window"]["MainWindow"]["Settings"]["MaxMemory"] = textBox2.Text;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            long input;
            if (long.TryParse(textBox4.Text, out input))
            {
                if (input > 2147483647)
                {
                    textBox4.Text = "2147483647";
                    return;
                }
                else if (input < 0)
                {
                    textBox4.Text = "0";
                    return;
                }
            }
            else
            {
                textBox4.Text = "";
                return;
            }

            try
            {
                Config.Config_json["Window"]["MainWindow"]["Settings"]["ClientWidth"] = textBox4.Text;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            long input;
            if (long.TryParse(textBox5.Text, out input))
            {
                if (input > 2147483647)
                {
                    textBox5.Text = "2147483647";
                    return;
                }
                else if (input < 0)
                {
                    textBox5.Text = "0";
                    return;
                }
            }
            else
            {
                textBox5.Text = ""; 
                return;
            }

            try
            {
                Config.Config_json["Window"]["MainWindow"]["Settings"]["ClientHeight"] = textBox5.Text;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Config_json["Window"]["MainWindow"]["Settings"]["JVMArguments"] = textBox3.Text;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Config_json["Window"]["MainWindow"]["Settings"]["JavaPath"] = textBox1.Text;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            await ClientLaunch.ClientDownload.StartJre();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Java可执行文件 (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Minecraft Mods, Minecraft Disabled Mods (*.jar;*.dis)|*.jar;*.dis";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Title = "添加本地模组";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (openFileDialog1.FileNames.Length > 0)
                {
                    string[] filesArray = openFileDialog1.FileNames;

                    try
                    {
                        foreach (string file in filesArray)
                        {
                            string newname = ClientLaunch.ClientInformation.ClientPath + "\\mods\\" + Path.GetFileName(file);
                            if (File.Exists(newname))
                            {
                                File.Delete(newname);
                            }
                            File.Copy(file, newname);
                        }
                        ClientLaunch.ClientInformation.Reload();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("在复制文件时出现错误: " + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                } else
                {
                    MessageBox.Show("请选择一个文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                return;
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", ClientLaunch.ClientInformation.ClientPath);
        }


        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ModsInjectMain.Reload();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Minecraft Mods, Minecraft Disabled Mods (*.jar;*.dis)|*.jar;*.dis";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Title = "添加本地模组";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (openFileDialog1.FileNames.Length > 0)
                {
                    string[] filesArray = openFileDialog1.FileNames;

                    try
                    {
                        foreach (string file in filesArray)
                        {
                            string newname = ModsInjectMain.ModsFolder + "\\" + Path.GetFileName(file);
                            if (File.Exists(newname))
                            {
                                File.Delete(newname);
                            }
                            File.Copy(file, newname);
                        }
                        ModsInjectMain.Reload();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("在复制文件时出现错误: " + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("请选择一个文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", ModsInjectMain.ModsFolder);
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left))
            {
                int selectedIndex = -1;
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    if (listView2.Items[i].Selected)
                    {
                        selectedIndex = i;
                        break;
                    }
                }

                if (selectedIndex != -1)
                {
                    ModsInjectMain.SwitchMod(selectedIndex);
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Config_json["Window"]["MainWindow"]["Settings"]["DeleteServerMods"] = checkBox1.Checked;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Config_json["Window"]["MainWindow"]["Settings"]["ShowSAuthLoginForm"] = checkBox2.Checked;
                Config.Save();
            }
            catch (Exception err)
            {
                ShowError("程序在保存配置时发生错误\r\n错误信息:" + err.Message);
            }
        }


    }
    }




