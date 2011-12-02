namespace Spofity
{
    partial class spotiEntry
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lArtist = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lName = new SpotifySmallLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lTime = new SpotifySmallLabel();
            this.sLabel1 = new SLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sLabel1);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.lArtist);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.lName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lTime);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 25);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Spofity.Properties.Resources.play;
            this.pictureBox3.Location = new System.Drawing.Point(44, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 16);
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // lArtist
            // 
            this.lArtist.AutoSize = true;
            this.lArtist.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lArtist.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lArtist.LinkColor = System.Drawing.Color.Silver;
            this.lArtist.Location = new System.Drawing.Point(478, -9);
            this.lArtist.Name = "lArtist";
            this.lArtist.Size = new System.Drawing.Size(0, 13);
            this.lArtist.TabIndex = 11;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Spofity.Properties.Resources.buy;
            this.pictureBox2.Location = new System.Drawing.Point(332, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 18);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lName.Location = new System.Drawing.Point(105, 5);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(34, 13);
            this.lName.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Spofity.Properties.Resources.rate;
            this.pictureBox1.Location = new System.Drawing.Point(434, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 16);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTime.ForeColor = System.Drawing.Color.Gray;
            this.lTime.Location = new System.Drawing.Point(400, 5);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(28, 13);
            this.lTime.TabIndex = 12;
            // 
            // sLabel1
            // 
            this.sLabel1.Location = new System.Drawing.Point(385, 3);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.Size = new System.Drawing.Size(43, 19);
            this.sLabel1.TabIndex = 17;
            // 
            // spotiEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "spotiEntry";
            this.Size = new System.Drawing.Size(519, 28);
            this.Load += new System.EventHandler(this.spotiEntry_Load);
            this.DoubleClick += new System.EventHandler(this.spotiEntry_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spotiEntry_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.spotiEntry_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spotiEntry_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel lArtist;
        private System.Windows.Forms.PictureBox pictureBox2;
        public SpotifySmallLabel lName;
        private System.Windows.Forms.PictureBox pictureBox1;
        public SpotifySmallLabel lTime;
        private SLabel sLabel1;





    }
}
