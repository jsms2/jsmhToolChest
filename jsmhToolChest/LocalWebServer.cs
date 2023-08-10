using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jsmhToolChest
{
    internal class LocalWebServer
    {
        private static string url = "http://127.0.0.1:20881/";
        public static Thread LocalWebServerThreadObj = new Thread(new ThreadStart(Loop));

        public static void Start()
        {
            try
            {
                LocalWebServerThreadObj.Start();
            } catch(Exception ex)
            {
                Program.mainWindow.ShowError("本地Web服务线程开始时发生错误: " + ex.Message);
            }
            
        }

        private static void Loop()
        {
            HttpListener listener = null;
            try
            {
                listener = new HttpListener();
                listener.Prefixes.Add(url);
                listener.Start();
            }
            catch (Exception ex) {
                Program.mainWindow.ShowError("本地Web服务开启时发生错误: " + ex.Message);
            }
            
            try
            {
                while (true)
                {
                    var context = listener.GetContext();
                    new Thread(ProcessRequest).Start(context);
                }
                
            }
            catch (Exception ex)
            {
                Program.mainWindow.ShowError("本地Web服务监听时发生错误: " + ex.Message);
            }
            finally
            {
                listener.Close();
            }
        }

        static void ProcessRequest(object contextTask)
        {
            try
            {
                HttpListenerContext context = (HttpListenerContext)contextTask;

                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                if (request == null)
                {
                    Program.mainWindow.LogTime();
                    Program.mainWindow.ErrorLogs("Web请求处理错误: 请求对象为空");
                    return;
                }

                string responseString = null;
                switch (request.Url.LocalPath)
                {
                    case "/GetConfig":
                        responseString = Config.Config_json.ToString();
                        response.StatusCode = 200;
                        response.ContentType = "application/json";
                        break;
                    default:
                        Program.mainWindow.LogTime();
                        Program.mainWindow.ErrorLogs($"Web请求处理错误: 获取到了无效的URL\"{request.Url.LocalPath}\"");
                        responseString = "Error 404";
                        response.StatusCode = 404;
                        break;
                }
                
                    


                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);


                response.ContentLength64 = buffer.Length;

                response.OutputStream.Write(buffer, 0, buffer.Length);

                response.Close();
            }
            catch (Exception ex)
            {
                Program.mainWindow.LogTime();
                Program.mainWindow.ErrorLogs("Web请求处理错误: " + ex.Message);
            }
        }
    }
}
