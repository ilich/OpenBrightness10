﻿namespace OpenBrightness10.Controls
{
    partial class LockPC
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
            this.lockButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lockButton
            // 
            this.lockButton.Location = new System.Drawing.Point(0, 0);
            this.lockButton.Name = "lockButton";
            this.lockButton.Size = new System.Drawing.Size(111, 39);
            this.lockButton.TabIndex = 0;
            this.lockButton.Text = "Lock PC";
            this.lockButton.UseVisualStyleBackColor = true;
            this.lockButton.Click += new System.EventHandler(this.OnLockButtonClick);
            // 
            // LockPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lockButton);
            this.Name = "LockPC";
            this.Size = new System.Drawing.Size(261, 61);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lockButton;
    }
}
