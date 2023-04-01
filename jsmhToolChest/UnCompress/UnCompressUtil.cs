
using System;
using System.Threading.Tasks;
using SharpCompress.Archives;
using SharpCompress.Common;

namespace jsmhToolChest.UnCompress
{
    internal class UnCompressUtil
    {
        public static bool done = false;
        public static async Task StartUnCompressAsync(string file, string folder, string title = "正在解压文件")
        {
            done = false;
            UnCompressForm form = new UnCompressForm();
            form.Show();
            form.Text = title;
            form.label1.Text = "正在解压" + file;
            form.label2.Text = "到" + folder;

            long totalSize = 0;
            long extractedSize = 0;

            using (var archive = ArchiveFactory.Open(file))
            {
                foreach (var entry in archive.Entries)
                {
                    if (!entry.IsDirectory)
                    {
                        totalSize += entry.Size;
                    }
                }

                archive.EntryExtractionBegin += (sender, e) =>
                {
                    Action action = () =>
                    {

                        form.label3.Text = "正在解压" + e.Item.Key;
                    };
                    form.Invoke(action);
                    
                };
                archive.EntryExtractionEnd += (sender, e) =>
                {
                    Action action = () =>
                    {
                        extractedSize += e.Item.Size;
                        double progress = (((double)extractedSize / totalSize) * 100);
                        form.progressBar1.Value = (int)progress;
                        form.label4.Text = $"已完成{(((double)extractedSize / totalSize) * 100):0.00}%";
                    };
                    form.Invoke(action);
                    
                };

                foreach (var entry in archive.Entries)
                {
                    if (!entry.IsDirectory)
                    {
                        await Task.Run(() => entry.WriteToDirectory(folder, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true }));
                    }
                }
            }
            done = true;
            form.Close();
        }


    }
}
