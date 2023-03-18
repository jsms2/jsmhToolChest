using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace jsmhToolChest
{
    internal class VersionCheck
    {
        public static bool IsLatestVersion()
        {
            try
            {
                WebClient client = new WebClient();
                string latestversion = client.DownloadString(Resource1.ServerURL + "Latest_version.txt");
                if (latestversion.Equals(""))
                {
                    Program.mainWindow.ShowError("服务器返回空\r\nWebside: https://jsmh.red/\r\nQQGuild: https://pd.qq.com/s/b8z1gt7f9\r\nGithub: https://github.com/jsms2/jsmhToolChest");
                }
                if (latestversion.Equals(Resource1.Version))
                {
                    return true;
                }
            } catch (Exception e)
            {
                Program.mainWindow.ShowError("获取服务器信息失败: "+e.Message + "\r\nWebside: https://jsmh.red/\r\nQQGuild: https://pd.qq.com/s/b8z1gt7f9\r\nGithub: https://github.com/jsms2/jsmhToolChest");
            }
            return false;
        }
    }
}
