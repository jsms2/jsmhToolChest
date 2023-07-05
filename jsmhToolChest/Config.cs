using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace jsmhToolChest
{
    internal class Config
    {
        public static JObject Config_json;
        public static string Config_folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\jsmh ToolChest";
        public static void Init()
        {
            
            if (!Directory.Exists(Config_folder))
            {
                Directory.CreateDirectory(Config_folder);
            }
            if (!Directory.Exists(Config.Config_folder + "\\Hook"))
            {
                Directory.CreateDirectory(Config.Config_folder + "\\Hook");
            }
            if (!Directory.Exists(Config.Config_folder + "\\.minecraft"))
            {
                Directory.CreateDirectory(Config.Config_folder + "\\.minecraft");
            }
            if (!Directory.Exists(Config.Config_folder + "\\InjectMods"))
            {
                Directory.CreateDirectory(Config.Config_folder + "\\InjectMods");
            }


            if (File.Exists(Config_folder + "\\Config.json"))
            {
                try
                {
                    Config_json = JObject.Parse(File.ReadAllText(Config_folder + "\\Config.json"));
                }catch (Exception e) {
                    Program.mainWindow.ShowError("程序在解析配置文件时发生错误\r\n错误文件:" + Config_folder + "\\Config.json\r\n错误信息:" + e.Message + "\r\n你可以尝试手动删除该文件");
                }
            } else
            {
                Config_json = new JObject();
            }

            if (!Config.Config_json.ContainsKey("Window"))
            {
                Config.Config_json.Add(new JProperty("Window", new JObject()));
            }
            if (!((JObject)Config.Config_json["Window"]).ContainsKey("MainWindow"))
            {
                ((JObject)Config.Config_json["Window"]).Add(new JProperty("MainWindow", new JObject()));
            }
            if (!((JObject)Config.Config_json["Window"]["MainWindow"]).ContainsKey("MainPage"))
            {
                ((JObject)Config.Config_json["Window"]["MainWindow"]).Add(new JProperty("MainPage", new JObject()));
            }
            if (!((JObject)Config.Config_json["Window"]["MainWindow"]).ContainsKey("Settings"))
            {
                ((JObject)Config.Config_json["Window"]["MainWindow"]).Add(new JProperty("Settings", new JObject()));
            }
            if (!((JObject)Config.Config_json["Window"]["MainWindow"]).ContainsKey("Client"))
            {
                ((JObject)Config.Config_json["Window"]["MainWindow"]).Add(new JProperty("Client", new JObject()));
            }
            if (!((JObject)Config.Config_json["Window"]["MainWindow"]["Client"]).ContainsKey("SelectClientInfo"))
            {
                ((JObject)Config.Config_json["Window"]["MainWindow"]["Client"]).Add(new JProperty("SelectClientInfo", new JObject()));
            }
            Save();
        }

        public static void Save()
        {
            File.WriteAllText(Config_folder + "\\Config.json",Config_json.ToString());
        }



    }
}
