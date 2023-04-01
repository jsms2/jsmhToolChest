using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace jsmhToolChest.Download
{
    internal class DownloadUtil
    {


        public static bool done = false;
        public static async Task StartDownloadAsync(string url, string path, string title = "正在下载文件")
        {
            done = false;
            DonwloadForm form = new DonwloadForm();
            form.Show();
            form.Text = title;
            form.label1.Text = "正在下载" + url;
            form.label2.Text = "到" + path;

            var client = new WebClient();

            try
            {
                var stopwatch = Stopwatch.StartNew();
                double last = 0;
                client.DownloadProgressChanged += (sender, e) =>
                {
                    if (stopwatch.Elapsed.TotalSeconds - last >= 0.2)
                    {
                        last = stopwatch.Elapsed.TotalSeconds;
                        double speed = e.BytesReceived / stopwatch.Elapsed.TotalSeconds;
                        form.progressBar1.Value = (int)(((double)e.BytesReceived / e.TotalBytesToReceive) * 100);
                        form.label3.Text = $"已下载 {((double)e.BytesReceived / 1024d / 1024d):0.00}MB/{((double)e.TotalBytesToReceive / 1024d / 1024d):0.00}MB";
                        form.label4.Text = $"{((double)speed / 1024d / 1024d):0.00} MB/s";
                    }
                };

                await client.DownloadFileTaskAsync(url, path);

            }
            finally
            {
                client.Dispose();
                done = true;
                form.Close();
            }

        }

    }
}
