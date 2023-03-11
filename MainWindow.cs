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

namespace jsmhToolChest
{
    public partial class MainWindow : Form
    {
        public Netease.RegeditRead regedit;
        bool StartBoxButton_isFirstClick = true;
        

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
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Process.GetCurrentProcess().Kill();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {


            Config.Init();
            try
            {
                if (((JObject)Config.Config_json["Window"]["MainWindow"]["MainPage"]).ContainsKey("Is4399"))
                {
                    is4399.Checked = (bool)Config.Config_json["Window"]["MainWindow"]["MainPage"]["Is4399"];
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
                            ShowError($"程序在读取配置时遇到了无法处理的值: Window.MainWindow.MainPage.StartMode的值为{StartMode}");
                            break;
                    }

                }


            } catch (Exception err)
            {
                ShowError("程序在读取配置时发生错误\r\n错误信息:" + err.Message);
            }

            LogBox.SelectionColor = Color.Orange;
            LogBox.SelectionFont = new Font(LogBox.Font.Name, 15, FontStyle.Bold);
            LogBox.AppendText("欢迎使用jsmhToolChest");

            


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
            try
            {
                WPFLauncher.WPFProcess.Kill();
                Process NeteaseClientProcess = NeteaseClient.GetNeteaseClientProcess();
                if (NeteaseClientProcess != null) { NeteaseClientProcess.Kill(); }

            } catch (Exception) { }
            Process.GetCurrentProcess().Kill();
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
            Clipboard.SetText(textBox_name.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_IP.Text);
        }
    }
    }




