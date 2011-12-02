namespace Spofity
{
    partial class spotifyButton
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
            this.SuspendLayout();
            // 
            // spotifyButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "spotifyButton";
            this.Load += new System.EventHandler(this.spotifyButton_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.spotifyButton_Paint);
            this.FontChanged += new System.EventHandler(this.spotifyButton_FontChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spotifyButton_MouseDown_1);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spotifyButton_MouseUp_1);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
