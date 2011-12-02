using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace Spofity
{
    public class SpotifyLabel : Label
    {
    
        public SpotifyLabel() 
        {
            this.ForeColor = Color.Gray;
            this.Font = new Font("Tahoma", 8.25f);
            this.Paint += new PaintEventHandler(SpotifyLabel_Paint);
        }

        void SpotifyLabel_Paint(object sender, PaintEventArgs e)
        {
 //           e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.Gray), new Point(-1, -1));
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
    public class SpotifySmallLabel : SLabel
    {
        public SpotifySmallLabel()
        {
      /*      this.ForeColor = Color.Black;
            this.Font = new Font("Tahoma", 8.25f);
            this.Paint += new PaintEventHandler(SpotifySmallLabel_Paint);*/
        }
      
        void SpotifySmallLabel_Paint(object sender, PaintEventArgs e)
        {
  //          e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.Gray), new Point(-1, -1));
        }
    }
 
}
