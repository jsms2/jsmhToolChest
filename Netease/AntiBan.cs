using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jsmhToolChest.Netease
{
    internal class AntiBan
    {
        public static Thread AntiBanThreadObj;
        private static Process NeteaseProcess;
        private static Libraries.ProcessModules.ProcessModule64 module;
        public static bool Start()
        {
            NeteaseProcess = NeteaseClient.GetNeteaseClientProcess();
            if (NeteaseProcess == null) { return false; }

            bool success = false;

            Libraries.ProcessModules.ProcessModule64[] modules = Libraries.ProcessModules.ProcessModules.getWOW64Modules(NeteaseProcess.Id);
            Debug.Print(modules.Length.ToString());
            foreach (Libraries.ProcessModules.ProcessModule64 Eachmodule in modules)
            {
                if (Eachmodule.ModuleName.Equals("api-ms-win-crt-utility-l1-1-1.dll"))
                {
                    module = Eachmodule;
                    success = true;
                }
            }
            if (!success)
            {
                return false;
            }

            AntiBanThreadObj = new Thread(new ThreadStart(AntibanThread));
            AntiBanThreadObj.Start();
            return true;

        }
        private static void AntibanThread()
        {
            byte[] data = { 195 };
            while (true)
            {
                Thread.Sleep(1000);
                Libraries.ProcessPatch.ProcessPatch.WriteProcessMemory(NeteaseProcess.Id, (ulong)(module.BaseAddress + 0x30F0), data, (ulong)data.Length);
                
            }
        }



    }
}
