﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using FastWin32.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Net;

namespace jsmhToolChest.Netease
{
    internal class Hook
    {
        private static string RandomString;

        public static void WriteHookFile()
        {
            try
            {
                Directory.CreateDirectory(Config.Config_folder + "\\Hook");
                File.WriteAllBytes(Config.Config_folder + "\\Hook\\Hook.dll", Resource1.Kupelo);
                File.WriteAllBytes(Config.Config_folder + "\\Hook\\Socket.dll", Resource1.Socket);
                File.WriteAllBytes(Config.Config_folder + "\\Hook\\DotNetDetour.dll", Resource1.DotNetDetour);
            } catch (Exception e)
            {
                Program.mainWindow.LogTime();
                Program.mainWindow.ErrorLogs("文件写出失败，详细信息:" + e.Message);
            }
        }

        public static void InjectHook()
        {
            RandomString = Libraries.String.GetRandomCharacters(16);
            uint processId = uint.Parse(WPFLauncher.WPFProcess.Id.ToString());
            string assemblyPath = Config.Config_folder + "\\Hook\\Hook.dll";
            int num;
            LocalPortListener.Start();
            Injector.InjectManaged(processId, assemblyPath, "ClassLibrary1.Class1", "init", RandomString, out num);
            
        }

        private static void HookMessageEvent(string message)
        {
            if ($"k_{RandomString}".Equals(message))
            {
                Program.mainWindow.LogTime();
                Program.mainWindow.SuccessLogs("Hook成功注入");
            }
        }

        public class LocalPortListener
        {
            private static Thread ListenerThread;
            private static TcpListener TCP;
            
            private static void Loop()
            {
                while(true)
                {
                    Socket s = TCP.AcceptSocket();
                    
                    Byte[] data = new Byte[s.ReceiveBufferSize];
                    s.Receive(data);
                    
                    string stringdata = Encoding.Default.GetString(data);
                    stringdata = stringdata.Replace(Encoding.Default.GetString(new byte[1]), "");
                    string Decode = Encoding.Default.GetString(Convert.FromBase64String(stringdata));
                    HookMessageEvent(Decode);
                    Debug.Print(Decode);
                    
                }
            }
            
            public static void Start()
            {
                
                TCP = new TcpListener(20880);
                TCP.Start();
                ListenerThread = new Thread(new ThreadStart(Loop));
                ListenerThread.Start();
            }

            public static void Stop()
            {
                try
                {
                    TCP.Stop();
                    ListenerThread.Abort();
                }catch (Exception)
                {

                }

            }
        }

    }
}
