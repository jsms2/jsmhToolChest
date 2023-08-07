using jsmhToolChest.Libraries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jsmhToolChest.Netease
{
    internal class Antiban
    {
        private static Thread AntibanThreadObj;
        public static void AntiBanThread()
        {
            Program.mainWindow.LogTime();
            Program.mainWindow.CustomLogs("内存防封线程已开启");

            Process NeteaseProcess = NeteaseClient.GetNeteaseClientProcess();
            if (NeteaseProcess != null )
            {
                bool loaded = false;
                int timeoutCount = 0;
                while (!loaded && timeoutCount < 50)
                {
                    Thread.Sleep(200);
                    try
                    {
                        
                        foreach(Libraries.ProcessModules.ProcessModule64 module in Libraries.ProcessModules.ProcessModules.getWOW64Modules(NeteaseProcess.Id))
                        {
                            if (module.ModuleName.Equals("api-ms-win-crt-utility-l1-1-1.dll"))
                            {
                                loaded = true;
                                break;
                            }
                        }
                    } catch (Exception ex)
                    {
                        Program.mainWindow.LogTime();
                        Program.mainWindow.ErrorLogs("内存防封开启发生错误: " + ex.ToString());
                        return;
                    }
                    if (!loaded)
                    {
                        timeoutCount++;
                    }
                }

                if (loaded)
                {
                    try
                    {
                        DLLInjector.InjectDLL("AntiBan.dll", Resource1.Antiban, NeteaseProcess);
                        Program.mainWindow.LogTime();
                        Program.mainWindow.SuccessLogs("内存防封已写入");
                    } catch (Exception ex)
                    {
                        Program.mainWindow.LogTime();
                        Program.mainWindow.ErrorLogs("内存防封开启发生错误: " + ex.ToString());
                    }
                    
                } else
                {
                    Program.mainWindow.LogTime();
                    Program.mainWindow.ErrorLogs("内存防封开启失败，模块等待超时");
                }
                    
            }
        }

        

        public static void Start()
        {
            Stop();
            AntibanThreadObj = new Thread(new ThreadStart(AntiBanThread));
            AntibanThreadObj.Start();
        }
        public static void Stop()
        {
            if ( AntibanThreadObj != null )
            {
                if (AntibanThreadObj.IsAlive)
                {
                    AntibanThreadObj.Abort();

                }
            }
            
            
        }
    }
}
