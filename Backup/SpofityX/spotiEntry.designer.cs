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
            this.lName = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.lNumber = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lArtist = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lName.Location = new System.Drawing.Point(64, 2);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 0;
            this.lName.Text = "label1";
            this.lName.DoubleClick += new System.EventHandler(this.lName_DoubleClick);
            this.lName.Click += new System.EventHandler(this.label1_Click);
            this.lName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lName_MouseDown);
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTime.ForeColor = System.Drawing.Color.Gray;
            this.lTime.Location = new System.Drawing.Point(359, 2);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(28, 13);
            this.lTime.TabIndex = 0;
            this.lTime.Text = "0:00";
            this.lTime.Click += new System.EventHandler(this.lTime_Click);
            // 
            // lNumber
            // 
            this.lNumber.AutoSize = true;
            this.lNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNumber.ForeColor = System.Drawing.Color.Gray;
            this.lNumber.Location = new System.Drawing.Point(19, 1);
            this.lNumber.Name = "lNumber";
            this.lNumber.Size = new System.Drawing.Size(13, 13);
            this.lNumber.TabIndex = 0;
            this.lNumber.Text = "1";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Spofity.Properties.Resources.play;
            this.pictureBox3.Location = new System.Drawing.Point(38, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 16);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Spofity.Properties.Resources.buy;
            this.pictureBox2.Location = new System.Drawing.Point(289, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 18);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Spofity.Properties.Resources.rate;
            this.pictureBox1.Location = new System.Drawing.Point(393, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 16);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lArtist
            // 
            this.lArtist.AutoSize = true;
            this.lArtist.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lArtist.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lArtist.LinkColor = System.Drawing.Color.Silver;
            this.lArtist.Location = new System.Drawing.Point(461, 3);
            this.lArtist.Name = "lArtist";
            this.lArtist.Size = new System.Drawing.Size(0, 13);
            this.lArtist.TabIndex = 4;
            this.lArtist.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lArtist_LinkClicked);
            this.lArtist.Click += new System.EventHandler(this.lArtist_Click);
            // 
            // spotiEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.lArtist);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lNumber);
            this.Controls.Add(this.lTime);
            this.Controls.Add(this.lName);
            this.Name = "spotiEntry";
            this.Size = new System.Drawing.Size(519, 20);
            this.Load += new System.EventHandler(this.spotiEntry_Load);
            this.DoubleClick += new System.EventHandler(this.spotiEntry_DoubleClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.spotiEntry_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spotiEntry_MouseDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spotiEntry_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.Label lNumber;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel lArtist;
    }
}
