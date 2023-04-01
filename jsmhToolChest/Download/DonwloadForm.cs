using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jsmhToolChest.Download
{
    public partial class DonwloadForm : Form
    {
        public DonwloadForm()
        {
            InitializeComponent();
        }

        private void DonwloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !DownloadUtil.done;
        }


    }
}
