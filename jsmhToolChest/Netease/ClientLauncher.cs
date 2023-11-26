using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;
using jsmhToolChest.Libraries.ProcessWindows;
using FastWin32.Diagnostics;

namespace jsmhToolChest.Netease
{
    /*
    internal class CL8
    {
        public static void WriteCL8()
        {
            Program.mainWindow.LogTime();
            try
            {
                File.WriteAllBytes(Program.mainWindow.regedit.GetGamePatch() + "\\Game\\.minecraft\\mods\\CL8🤔😋😅🤣😂😡.jar", Resource1.CL8);
                Program.mainWindow.SuccessLogs("CL8写出成功");
            } catch (Exception e)
            {
                Program.mainWindow.ErrorLogs("CL8写出错误，错误信息: " + e.Message);
            }
            
        }

    }
    */

    internal class OpenOpenCL
    {
        private static Thread clThreadObj ;
        public static void Start() {
            Stop();
            clThreadObj = new Thread(ClThread);
            clThreadObj.Start();
        }
        public static void Stop()
        {
            if (clThreadObj != null)
            {
                if (clThreadObj.IsAlive)
                {
                    clThreadObj.Abort();
                }
            }
        }
        static void ClThread()
        {
            Program.mainWindow.LogTime();
            Program.mainWindow.CustomLogs("CL注入线程已开启");
            Process neteaseProcess = NeteaseClient.GetNeteaseClientProcess();
            bool isStarted = false;
            while (!neteaseProcess.HasExited)
            {
                Thread.Sleep(200);
                ProcessWindows.ProcessWindow[] windows = ProcessWindows.GetProcessWindows(neteaseProcess);
                foreach (ProcessWindows.ProcessWindow win in windows)
                {
                    if (win.ClassName == "LWJGL")
                    {
                        isStarted = true;
                        break;
                    }
                }

                if (isStarted)
                {
                    Program.mainWindow.LogTime();
                    Program.mainWindow.SuccessLogs("CL已注入");
                    Libraries.DLLInjector.InjectDLL("OpenOpenCL.dll", Resource1.OpenOpenCL, neteaseProcess);
                    return;
                }
            }

        }
    }
}
