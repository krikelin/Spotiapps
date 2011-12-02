using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Spofity
{
    public partial class frmBitmap : Form
    {
        public frmBitmap()
        {
            InitializeComponent();
        }
        public frmBitmap(Bitmap X)
        {
            InitializeComponent();
            this.BackgroundImage = X;
        }
        private void frmBitmap_Load(object sender, EventArgs e)
        {

        }
    }
}
