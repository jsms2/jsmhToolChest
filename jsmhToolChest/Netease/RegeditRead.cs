using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace jsmhToolChest.Netease
{
    public class RegeditRead
    {
        public bool is4399 { get; set; }
        //bool is4399;
        private RegistryKey reg;
        public RegeditRead(bool is4399 = false)
        {
            this.is4399 = is4399;
            //is43991 = is4399;
            reg = Registry.CurrentUser.OpenSubKey(is4399 ? "SOFTWARE\\Netease\\PC4399_MCLauncher" : "SOFTWARE\\Netease\\MCLauncher");
        }


        public String GetInstallPatch()
        {
            string patch = "";
            try
            {
                patch = reg.GetValue("InstallLocation").ToString();
            } catch (Exception)
            {}
            return patch ;
        }

        public String GetGamePatch()
        {
            string patch = "";
            try
            {
                patch = reg.GetValue("DownloadPath").ToString();
            }
            catch (Exception)
            { }
            return patch;
        }

        public String GetWPFPatch()
        {
            return GetInstallPatch() + (is4399 ? "\\PC4399_WPFLauncher.exe" : "\\WPFLauncher.exe");
        }

        public String GetWPFName()
        {
            return is4399 ? "PC4399_WPFLauncher" : "WPFLauncher";
        }

    }
}
