using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace Spofity
{
    public partial class CDNotice : UserControl
    {
        public string Number
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }
        public CDNotice()
        {
            InitializeComponent();
        }

        private void CDNotice_Load(object sender, EventArgs e)
        {

        }
    }
}
