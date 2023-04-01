using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jsmhToolChest.UnCompress
{
    public partial class UnCompressForm : Form
    {
        public UnCompressForm()
        {
            InitializeComponent();
        }

        private void UnCompressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !UnCompressUtil.done;
        }

    }
}
