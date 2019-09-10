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
            this.lockPC = new OpenBrightness10.Controls.LockPC();
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
            this.tableLayoutPanel1.Controls.Add(this.lockPC, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(651, 204);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // displayBrightness
            // 
            this.displayBrightness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayBrightness.Location = new System.Drawing.Point(13, 13);
            this.displayBrightness.Name = "displayBrightness";
            this.displayBrightness.ScreenManager = null;
            this.displayBrightness.Size = new System.Drawing.Size(625, 55);
            this.displayBrightness.TabIndex = 0;
            // 
            // setBrightness
            // 
            this.setBrightness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setBrightness.Location = new System.Drawing.Point(13, 74);
            this.setBrightness.Name = "setBrightness";
            this.setBrightness.ScreenManager = null;
            this.setBrightness.Size = new System.Drawing.Size(625, 55);
            this.setBrightness.TabIndex = 1;
            // 
            // lockPC
            // 
            this.lockPC.ComputerManager = null;
            this.lockPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lockPC.Location = new System.Drawing.Point(13, 135);
            this.lockPC.Name = "lockPC";
            this.lockPC.Size = new System.Drawing.Size(625, 56);
            this.lockPC.TabIndex = 2;
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
            this.notifyIconMenu.Size = new System.Drawing.Size(131, 68);
            // 
            // menuOpen
            // 
            this.menuOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(130, 32);
            this.menuOpen.Text = "Open";
            this.menuOpen.Click += new System.EventHandler(this.OnMenuOpenClick);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(130, 32);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.OnMenuExitClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(651, 204);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private Controls.LockPC lockPC;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconMenu;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
    }
}

