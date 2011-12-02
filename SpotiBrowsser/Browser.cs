using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpotiBrowsser
{
    public partial class Browser : UserControl
    {
        private string  uri;
        public Browser(string Uri)
        {
            uri = Uri;
            this.webBrowser1.Navigate(Uri);
            InitializeComponent();
            
        }
        
    }
}
