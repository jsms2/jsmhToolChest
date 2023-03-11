using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace jsmhToolChest.Netease
{
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
}
