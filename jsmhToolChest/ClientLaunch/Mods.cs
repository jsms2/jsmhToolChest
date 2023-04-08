using Newtonsoft.Json;
using SharpCompress.Archives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpCompress.Archives.Zip;
using System.Diagnostics;
using System.Drawing;

namespace jsmhToolChest.ClientLaunch
{
    internal class Mods
    {
        public class ModInformation
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string ModID { get; set; }
            public string Version { get; set; }
            public string MCVersion { get; set; }
            public string URL { get; set; }
            public string[] AuthorList { get; set; }
            public string Credits { get; set; }
            public string LogoFile { get; set; }
            public string[] Screenshots { get; set; }
            public string[] Dependencies { get; set; }
        }

        public static ModInformation GetModInformation(string path)
        {
            ModInformation modInfo = null;
            try
            {
                using (IArchive archive = ZipArchive.Open(path))
                {
                    var entry = archive.Entries.FirstOrDefault(x => x.Key.Equals("mcmod.info", StringComparison.OrdinalIgnoreCase));
                    if (entry != null)
                    {
                        using (Stream stream = entry.OpenEntryStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                string jsonString = reader.ReadToEnd();
                                modInfo = JsonConvert.DeserializeObject<ModInformation[]>(jsonString)[0];
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("无法在模组文件内找到mcmod.info");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("无法打开jar文件或解析mcmod.info文件", ex);
            }
            if (modInfo == null)
            {
                throw new Exception("无法打开jar文件或解析mcmod.info文件");
            }
            return modInfo;
        }

        public static void ShowModInfomation(string path)
        {
            try
            {
                ModInformation mod = GetModInformation(path);
                
                ModInfomationForm form = new ModInfomationForm();
                string modfilename = Path.GetFileName(path);
                form.label10.Text = modfilename == null ? "None" : modfilename;
                form.label11.Text = mod.Name == null ? "None" : mod.Name;
                form.label12.Text = mod.Version == null ? "None" : mod.Version;
                form.label13.Text = mod.MCVersion == null ? "None" : mod.MCVersion;
                form.linkLabel1.Text = mod.URL == null ? "None" : mod.URL;
                if (mod.URL != null)
                {
                    form.linkLabel1.LinkClicked += (object sender, LinkLabelLinkClickedEventArgs e) => {
                        try
                        {
                            Process.Start(mod.URL);
                        } catch (Exception er)
                        {
                            MessageBox.Show("在打开链接时发生错误: " + er.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
                } else
                {
                    form.linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;
                    form.linkLabel1.LinkColor = Color.Black;
                    form.linkLabel1.VisitedLinkColor = Color.Black;
                }
                form.label14.Text = mod.Description == null ? "None" : mod.Description;
                form.label8.Location = new Point(form.label8.Location.X, form.label14.Location.Y + form.label14.Size.Height);
                form.label15.Location = new Point(form.label15.Location.X, form.label14.Location.Y + form.label14.Size.Height);
                form.label15.Text = MergeStrings(mod.AuthorList);
                form.label9.Location = new Point(form.label9.Location.X, form.label15.Location.Y + form.label15.Size.Height);
                form.label16.Location = new Point(form.label16.Location.X, form.label15.Location.Y + form.label15.Size.Height);
                form.label16.Text = MergeStrings(mod.Dependencies);
                form.panel1.Size = new Size(form.panel1.Size.Width, form.label16.Location.Y + form.label16.Size.Height + 135);
                FileInfo info = new FileInfo(path);
                form.label17.Text = FormatFileSize(info.Length);
                form.Text = "模组信息: " + Path.GetFileNameWithoutExtension(path);
                form.ShowDialog();
                

            } catch (Exception e)
            {
                MessageBox.Show("在获取模组信息时出现错误: " + e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private static string MergeStrings(string[] input)
        {
            if (input == null || input.Length == 0)
            {
                return string.Empty;
            }

            return string.Join("\r\n", input);
        }
        private static string FormatFileSize(long fileSizeInBytes)
        {
            if (fileSizeInBytes < 1024)
            {
                return fileSizeInBytes + " 字节";
            }
            else if (fileSizeInBytes < 1024 * 1024)
            {
                double fileSizeInKB = (double)fileSizeInBytes / 1024;
                return fileSizeInBytes + " 字节" + " (" + fileSizeInKB.ToString("0.00") + " KB)";
            }
            else if (fileSizeInBytes < 1024 * 1024 * 1024)
            {
                double fileSizeInMB = (double)fileSizeInBytes / (1024 * 1024);
                return fileSizeInBytes + " 字节" + " (" + fileSizeInMB.ToString("0.00") + " MB)";
            }
            else
            {
                double fileSizeInGB = (double)fileSizeInBytes / (1024 * 1024 * 1024);
                return fileSizeInBytes + " 字节" + " (" + fileSizeInGB.ToString("0.00") + " GB)";
            }
        }
    }
}
