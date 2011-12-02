namespace Miami
{
    partial class Browse
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
            this.pane1 = new Spofity.pane();
            this.sLabel1 = new Spofity.SLabel();
            this.sLabel2 = new Spofity.SLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sLabel3 = new Spofity.SLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.spotifyButton1 = new Spofity.spotifyButton();
            this.spotifyLabel1 = new Spofity.SpotifyLabel();
            this.page1 = new Spofity.page();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pane1
            // 
            this.pane1.Active = false;
            this.pane1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pane1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pane1.Label = "Search result";
            this.pane1.Location = new System.Drawing.Point(0, 50);
            this.pane1.Name = "pane1";
            this.pane1.Sect = null;
            this.pane1.Size = new System.Drawing.Size(709, 21);
            this.pane1.TabIndex = 0;
            // 
            // sLabel1
            // 
            this.sLabel1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sLabel1.ForeColor = System.Drawing.Color.White;
            this.sLabel1.Label = "Emotionalizer";
            this.sLabel1.Location = new System.Drawing.Point(55, 10);
            this.sLabel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.Size = new System.Drawing.Size(222, 32);
            this.sLabel1.TabIndex = 1;
            // 
            // sLabel2
            // 
            this.sLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.sLabel2.Label = "Describe your emotion and SpotiApps will propose some fitting playlists for you";
            this.sLabel2.Location = new System.Drawing.Point(284, 22);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.Size = new System.Drawing.Size(401, 20);
            this.sLabel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Miami.Properties.Resources.emotions2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(12, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 35);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // sLabel3
            // 
            this.sLabel3.ForeColor = System.Drawing.Color.DarkGray;
            this.sLabel3.Label = "How do you feel?";
            this.sLabel3.Location = new System.Drawing.Point(24, 85);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(95, 19);
            this.sLabel3.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Normal",
            "Sad",
            "Angry",
            "Love",
            "Busy",
            "Hurry"});
            this.comboBox1.Location = new System.Drawing.Point(128, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(149, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // spotifyButton1
            // 
            this.spotifyButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.spotifyButton1.InsideGroup = false;
            this.spotifyButton1.Label = "I\'m lucky";
            this.spotifyButton1.Location = new System.Drawing.Point(301, 85);
            this.spotifyButton1.Name = "spotifyButton1";
            this.spotifyButton1.Size = new System.Drawing.Size(150, 31);
            this.spotifyButton1.TabIndex = 8;
            this.spotifyButton1.Load += new System.EventHandler(this.spotifyButton1_Load);
            this.spotifyButton1.Click += new System.EventHandler(this.spotifyButton1_Click);
            this.spotifyButton1.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.spotifyButton1_ChangeUICues);
            // 
            // spotifyLabel1
            // 
            this.spotifyLabel1.AutoSize = true;
            this.spotifyLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.spotifyLabel1.ForeColor = System.Drawing.Color.Gray;
            this.spotifyLabel1.Location = new System.Drawing.Point(310, 273);
            this.spotifyLabel1.Name = "spotifyLabel1";
            this.spotifyLabel1.Size = new System.Drawing.Size(46, 13);
            this.spotifyLabel1.TabIndex = 9;
            this.spotifyLabel1.Text = "Working";
            this.spotifyLabel1.Visible = false;
            // 
            // page1
            // 
            this.page1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.page1.Location = new System.Drawing.Point(3, 132);
            this.page1.Name = "page1";
            this.page1.Size = new System.Drawing.Size(709, 15);
            this.page1.TabIndex = 5;
            // 
            // Browse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.spotifyLabel1);
            this.Controls.Add(this.spotifyButton1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.sLabel3);
            this.Controls.Add(this.page1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sLabel2);
            this.Controls.Add(this.sLabel1);
            this.Controls.Add(this.pane1);
            this.Name = "Browse";
            this.Size = new System.Drawing.Size(709, 507);
            this.Load += new System.EventHandler(this.Browse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Spofity.pane pane1;
        private Spofity.SLabel sLabel1;
        private Spofity.SLabel sLabel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Spofity.SLabel sLabel3;
        private System.Windows.Forms.ComboBox comboBox1;
        private Spofity.spotifyButton spotifyButton1;
        private Spofity.SpotifyLabel spotifyLabel1;
        private Spofity.page page1;

    }
}
