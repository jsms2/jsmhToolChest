using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Odbc;

namespace jsmhToolChest.ClientLaunch
{
    public partial class AddClientForm : Form
    {
        public AddClientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.Description = "请选择一个目录";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog1.SelectedPath = Config.Config_folder + "\\.minecraft";
            folderBrowserDialog1.ShowNewFolderButton = true;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("请输入名称","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("请输入目录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(textBox2.Text))
            {
                MessageBox.Show("请输入有效的目录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ClientList.AddClient(textBox1.Text,textBox2.Text);
            ClientList.ReloadClientList();
            this.Close();
        }
    }
}
