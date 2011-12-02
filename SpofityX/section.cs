using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spofity
{
    public partial class section : UserControl
    {
        public section()
        {
            InitializeComponent();
        }
        private Form1 host;
        public section(Form1 Host)
        {
            host = Host;
            InitializeComponent();
        }
        private void section_Load(object sender, EventArgs e)
        {

        }
    }
}
