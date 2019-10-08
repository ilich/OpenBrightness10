﻿namespace OpenBrightness10.Controls
{
    partial class DisplayBrightness
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.brightness = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lux = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sensorName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.brightness);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.lux);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.sensorName);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(426, 64);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Screen Brightness:";
            // 
            // brightness
            // 
            this.brightness.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.brightness, true);
            this.brightness.Location = new System.Drawing.Point(137, 0);
            this.brightness.Name = "brightness";
            this.brightness.Size = new System.Drawing.Size(28, 17);
            this.brightness.TabIndex = 1;
            this.brightness.Text = "0%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Luminous Emmitance:";
            // 
            // lux
            // 
            this.lux.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.lux, true);
            this.lux.Location = new System.Drawing.Point(155, 17);
            this.lux.Name = "lux";
            this.lux.Size = new System.Drawing.Size(16, 17);
            this.lux.TabIndex = 3;
            this.lux.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sensor:";
            // 
            // sensorName
            // 
            this.sensorName.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.sensorName, true);
            this.sensorName.Location = new System.Drawing.Point(66, 34);
            this.sensorName.Name = "sensorName";
            this.sensorName.Size = new System.Drawing.Size(0, 17);
            this.sensorName.TabIndex = 5;
            // 
            // DisplayBrightness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DisplayBrightness";
            this.Size = new System.Drawing.Size(426, 64);
            this.Load += new System.EventHandler(this.OnLoad);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label brightness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lux;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label sensorName;
    }
}
