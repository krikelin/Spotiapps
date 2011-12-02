namespace SpotiApp
{
    partial class Playlists
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spotifyLabel1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ucSection1 = new ucSection();
            this.spotifyButton1 = new Spofity.spotifyButton();
            this.SuspendLayout();
            // 
            // spotifyLabel1
            // 
            this.spotifyLabel1.AutoSize = true;
            this.spotifyLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.spotifyLabel1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.spotifyLabel1.Location = new System.Drawing.Point(23, 15);
            this.spotifyLabel1.Name = "spotifyLabel1";
            this.spotifyLabel1.Size = new System.Drawing.Size(165, 24);
            this.spotifyLabel1.TabIndex = 0;
            this.spotifyLabel1.Text = "Search for playlists";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.CausesValidation = false;
            this.textBox1.Location = new System.Drawing.Point(27, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(654, 13);
            this.textBox1.TabIndex = 1;
            // 
            // ucSection1
            // 
            this.ucSection1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSection1.BackColor = System.Drawing.Color.Gray;
            this.ucSection1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSection1.Location = new System.Drawing.Point(-3, 100);
            this.ucSection1.Name = "ucSection1";
            this.ucSection1.Size = new System.Drawing.Size(920, 32);
            this.ucSection1.TabIndex = 2;
            this.ucSection1.Title = "Playlists";
            // 
            // spotifyButton1
            // 
            this.spotifyButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.spotifyButton1.InsideGroup = false;
            this.spotifyButton1.Label = "Search";
            this.spotifyButton1.Location = new System.Drawing.Point(697, 53);
            this.spotifyButton1.Name = "spotifyButton1";
            this.spotifyButton1.Size = new System.Drawing.Size(82, 31);
            this.spotifyButton1.TabIndex = 3;
            this.spotifyButton1.Load += new System.EventHandler(this.spotifyButton1_Load);
            this.spotifyButton1.Click += new System.EventHandler(this.spotifyButton1_Click);
            // 
            // Playlists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.spotifyButton1);
            this.Controls.Add(this.ucSection1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.spotifyLabel1);
            this.Name = "Playlists";
            this.Size = new System.Drawing.Size(920, 603);
            this.Load += new System.EventHandler(this.Playlists_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label spotifyLabel1;
        private System.Windows.Forms.TextBox textBox1;
        private ucSection ucSection1;
        private Spofity.spotifyButton spotifyButton1;
    }
}
