using OpenBrightness10.Controls;
using OpenBrightness10.Devices;
using System;
using System.Windows.Forms;

namespace OpenBrightness10
{
    partial class Main : Form
    {
        private readonly ScreenManager screenManager = new ScreenManager();

        public Main()
        {
            InitializeComponent();
            SetScreenManager(screenManager, displayBrightness);
            SetScreenManager(screenManager, setBrightness);
        }

        private void SetScreenManager(
            ScreenManager screenManager, 
            BrightnessAwareUserControl control)
        {
            if (screenManager == null)
            {
                return;
            }

            control.AddBrightnessChangeListener(screenManager);
            control.SetBightnessProvider(screenManager);
        }

        private void OnLoad(object sender, System.EventArgs e)
        {
            screenManager.Start();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void OnNotifyIconDoubleClick(object sender, EventArgs e)
        {
            Show();
        }

        private void OnMenuOpenClick(object sender, EventArgs e)
        {
            Show();
        }

        private void OnMenuExitClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
