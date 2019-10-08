﻿namespace OpenBrightness10.Controls
{
    partial class SensorManager
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
            this.sensorEnabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sensorName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.sensorName);
            this.flowLayoutPanel1.Controls.Add(this.sensorEnabled);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(547, 79);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // sensorEnabled
            // 
            this.sensorEnabled.AutoSize = true;
            this.sensorEnabled.Enabled = false;
            this.sensorEnabled.Location = new System.Drawing.Point(3, 20);
            this.sensorEnabled.Name = "sensorEnabled";
            this.sensorEnabled.Size = new System.Drawing.Size(151, 21);
            this.sensorEnabled.TabIndex = 0;
            this.sensorEnabled.Text = "Enable light sensor";
            this.sensorEnabled.UseVisualStyleBackColor = true;
            this.sensorEnabled.CheckedChanged += new System.EventHandler(this.OnSensorEnabledCheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sensor:";
            // 
            // sensorName
            // 
            this.sensorName.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.sensorName, true);
            this.sensorName.Location = new System.Drawing.Point(66, 0);
            this.sensorName.Name = "sensorName";
            this.sensorName.Size = new System.Drawing.Size(0, 17);
            this.sensorName.TabIndex = 2;
            // 
            // SensorManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "SensorManager";
            this.Size = new System.Drawing.Size(547, 79);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox sensorEnabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sensorName;
    }
}