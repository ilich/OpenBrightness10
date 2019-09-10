namespace OpenBrightness10.Controls
{
    partial class SetBrightness
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
            this.brightness = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.brightness)).BeginInit();
            this.SuspendLayout();
            // 
            // brightness
            // 
            this.brightness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brightness.Location = new System.Drawing.Point(0, 0);
            this.brightness.Maximum = 100;
            this.brightness.Name = "brightness";
            this.brightness.Size = new System.Drawing.Size(623, 64);
            this.brightness.TabIndex = 0;
            this.brightness.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnBrightnessMouseDown);
            this.brightness.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnBrightnessMouseUp);
            // 
            // SetBrightness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.brightness);
            this.Name = "SetBrightness";
            this.Size = new System.Drawing.Size(623, 64);
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.brightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar brightness;
    }
}
