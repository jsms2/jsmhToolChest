using FastWin32.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace jsmhToolChest.Netease
{
    internal class WPFLauncher
    {
        public static Process WPFProcess = new Process();
        public static bool TestedNeteaseClient = false;
        private static bool TestedNeteaseFolderCreate = false;
        public static Thread NeteaseClientTestThreadObj;
        public async static Task Launch()
        {
            await Task.Run(() =>
            {
                Kill();
                Hook.WriteHookFile();
                WPFProcess.StartInfo.FileName = Program.mainWindow.regedit.GetWPFPatch();
                Program.mainWindow.LogTime();
                Program.mainWindow.CustomLogs("准备启动盒子");
                WPFProcess.Start();
                Program.mainWindow.LogTime();
                Program.mainWindow.CustomLogs("盒子已启动 PID:" + WPFProcess.Id.ToString());

                bool loaded = false;
                int timeoutCount = 0;
                while (!loaded && timeoutCount < 50)
                {
                    Thread.Sleep(200);
                    try
                    {
                        WPFProcess.Refresh();
                        foreach (ProcessModule module in WPFProcess.Modules)
                        {

                            if (module.ModuleName == "ncrypt.dll")
                            {
                                loaded = true;
                                break;
                            }
                        }
                    } catch
                    {

                    }
                    if (!loaded)
                    {
                        timeoutCount++;
                    }

                }

                if (loaded)
                {
                    Program.mainWindow.LogTime();
                    Program.mainWindow.CustomLogs("盒子模块已加载，开始注入Hook");
                    try
                    {
                        Hook.InjectHook();
                        NeteaseClientTestThreadObj = new Thread(new ThreadStart(NeteaseTestThread));
                        NeteaseClientTestThreadObj.Start();
                    } catch (Exception e)
                    {
                        Program.mainWindow.LogTime();
                        Program.mainWindow.ErrorLogs("盒子启动失败 详细信息:" + e.Message);
                    }
                    

                }
                else
                {
                    Program.mainWindow.LogTime();
                    Program.mainWindow.ErrorLogs("等待盒子模块加载超时，请重试");
                }
                
            });
            

        }
        public static void Kill()
        {

            Process[] WPF = Process.GetProcessesByName(Program.mainWindow.regedit.GetWPFName());
            foreach (Process WPFProce in WPF)
            {
                Program.mainWindow.LogTime();
                Program.mainWindow.CustomLogs($"结束进程{WPFProce.ProcessName} PID:{WPFProce.Id}");
                WPFProce.Kill();
            }
            Process Netease = NeteaseClient.GetNeteaseClientProcess();
            if (Netease != null)
            {
                Program.mainWindow.LogTime();
                Program.mainWindow.CustomLogs($"结束进程{Netease.ProcessName} PID:{Netease.Id}");
                Netease.Kill();
            }
        }

        public static void NeteaseTestThread()
        {
            while(true)
            {
                Thread.Sleep(100);
                Process NeteastClientProcess = NeteaseClient.GetNeteaseClientProcess();
                if (NeteastClientProcess != null && !TestedNeteaseClient)
                {
                    TestedNeteaseClient = true;
                    Program.mainWindow.LogTime();
                    Program.mainWindow.SuccessLogs($"网易客户端已成功启动 PID:{NeteastClientProcess.Id}");
                    Program.mainWindow.ChangeStartBoxText("结束白端");

                    if(Program.mainWindow.checkBox1.Checked || Program.mainWindow.Radio_Client.Checked)
                    {
                        DeleteServerMods();
                    }
                    if (Program.mainWindow.Radio_Client.Checked)
                    {
                        if (Program.mainWindow.radioButton1.Checked)
                        {
                            CL8.WriteCL8();
                        }
                    }
                    if (Program.mainWindow.Radio_Mods.Checked)
                    {
                        ModsInject.ModsInjectMain.WriteMods();
                    }
                    
                    try
                    {
                        string PlayerName = Libraries.String.GetMiddleString(NeteastClientProcess.StartInfo.Arguments, "--username ", " ");
                        string ServerIP = Libraries.String.GetMiddleString(NeteastClientProcess.StartInfo.Arguments, "--server ", " ");
                        string ServerPort = Libraries.String.GetMiddleString(NeteastClientProcess.StartInfo.Arguments, "--port ", " ");
                        Program.mainWindow.LogTime();
                        Program.mainWindow.CustomLogs("已获取到网易客户端信息");
                        Program.mainWindow.LogTime();
                        Program.mainWindow.CustomLogs("游戏名: ");
                        Program.mainWindow.ImportantLogs(PlayerName);
                        Program.mainWindow.LogTime();
                        Program.mainWindow.CustomLogs("服务器IP: ");
                        Program.mainWindow.ImportantLogs($"{ServerIP}:{ServerPort}");

                        Action action = () =>
                        {
                            Program.mainWindow.textBox_name.Text = PlayerName;
                            Program.mainWindow.textBox_IP.Text = $"{ServerIP}:{ServerPort}";
                        };
                        Program.mainWindow.Invoke(action);
                        

                    } catch (Exception e)
                    {
                        Program.mainWindow.LogTime();
                        Program.mainWindow.CustomLogs("获取网易客户端信息失败: " + e.Message);
                    }

                    Antiban.Start();
                    
                }
                if (NeteastClientProcess == null && TestedNeteaseClient)
                {
                    TestedNeteaseClient = false;
                    Program.mainWindow.LogTime();
                    Program.mainWindow.CustomLogs($"网易客户端已结束");
                    Program.mainWindow.ChangeStartBoxText("重启盒子");

                    Antiban.Stop();
                }
            }
        }

        public static void DeleteServerMods()
        {
            string ModsFolder = Program.mainWindow.regedit.GetGamePatch() + "\\Game\\.minecraft\\mods\\";
            foreach (string filepath in Directory.GetFiles(ModsFolder, "*.jar"))
            {
                try
                {
                    FileInfo file = new FileInfo(filepath);
                    string filename = file.Name;
                    if (filename.IndexOf("@3@0") == -1) {
                        file.Delete();
                        Program.mainWindow.LogTime();
                        Program.mainWindow.SuccessLogs($"模组{filename}已删除");
                    }
                    
                    
                }
                catch (Exception e)
                {
                    Program.mainWindow.LogTime();
                    Program.mainWindow.ErrorLogs($"在删除单个模组{filepath}时发生错误: {e.Message}");
                }
            }
                
        }
    }
}
