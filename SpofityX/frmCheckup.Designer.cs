namespace Spofity
{
    partial class frmCheckup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.app1 = new app();
            this.SuspendLayout();
            // 
            // app1
            // 
            this.app1.Active = true;
            this.app1.Dock = System.Windows.Forms.DockStyle.Left;
            this.app1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.app1.Label = "Spotify";
            this.app1.Location = new System.Drawing.Point(0, 0);
            this.app1.Name = "app1";
            this.app1.Sect = null;
            this.app1.Size = new System.Drawing.Size(81, 18);
            this.app1.TabIndex = 0;
            this.app1.Click += new System.EventHandler(this.app1_Click);
            this.app1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.app1_MouseDown);
            // 
            // frmCheckup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = global::Spofity.Properties.Resources.place3;
            this.ClientSize = new System.Drawing.Size(743, 18);
            this.Controls.Add(this.app1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCheckup";
            this.Text = "frmCheckup";
            this.Load += new System.EventHandler(this.frmCheckup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private app app1;






    }
}