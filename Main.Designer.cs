namespace OpenBrightness10
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.displayBrightness = new OpenBrightness10.Controls.DisplayBrightness();
            this.setBrightness = new OpenBrightness10.Controls.SetBrightness();
            this.sensorManager = new OpenBrightness10.Controls.SensorManager();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.notifyIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.displayBrightness, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.setBrightness, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.sensorManager, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.88889F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(542, 196);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // displayBrightness
            // 
            this.displayBrightness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayBrightness.Location = new System.Drawing.Point(10, 10);
            this.displayBrightness.Margin = new System.Windows.Forms.Padding(2);
            this.displayBrightness.Name = "displayBrightness";
            this.displayBrightness.Size = new System.Drawing.Size(522, 48);
            this.displayBrightness.TabIndex = 0;
            // 
            // setBrightness
            // 
            this.setBrightness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setBrightness.Location = new System.Drawing.Point(10, 62);
            this.setBrightness.Margin = new System.Windows.Forms.Padding(2);
            this.setBrightness.Name = "setBrightness";
            this.setBrightness.Size = new System.Drawing.Size(522, 44);
            this.setBrightness.TabIndex = 1;
            // 
            // sensorManager
            // 
            this.sensorManager.Location = new System.Drawing.Point(11, 111);
            this.sensorManager.Name = "sensorManager";
            this.sensorManager.Size = new System.Drawing.Size(520, 55);
            this.sensorManager.TabIndex = 2;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.OnNotifyIconDoubleClick);
            // 
            // notifyIconMenu
            // 
            this.notifyIconMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuExit});
            this.notifyIconMenu.Name = "notifyIconMenu";
            this.notifyIconMenu.Size = new System.Drawing.Size(116, 52);
            // 
            // menuOpen
            // 
            this.menuOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(115, 24);
            this.menuOpen.Text = "Open";
            this.menuOpen.Click += new System.EventHandler(this.OnMenuOpenClick);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(115, 24);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.OnMenuExitClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(542, 196);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Open Brightness 10";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.notifyIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.DisplayBrightness displayBrightness;
        private Controls.SetBrightness setBrightness;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconMenu;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private Controls.SensorManager sensorManager;
    }
}

