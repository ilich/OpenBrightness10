using OpenBrightness10.Controls;
using OpenBrightness10.Devices;
using System;
using System.Windows.Forms;

namespace OpenBrightness10
{
    partial class Main : Form
    {
        private readonly ScreenManager screenManager = new ScreenManager();

        private readonly YoctoLightV3Manager lightSensor = new YoctoLightV3Manager();

        public Main()
        {
            InitializeComponent();
            SetScreenManager(screenManager, displayBrightness);
            SetScreenManager(screenManager, setBrightness);
            SetLightMeter(lightSensor, displayBrightness);
            setBrightness.AddBrightnessChangeListener(lightSensor);
            lightSensor.Enabled = true;
        }

        private void SetScreenManager(
            ScreenManager screenManager, 
            BrightnessAwareUserControl control)
        {
            if (screenManager == null)
            {
                throw new ArgumentNullException(nameof(screenManager));
            }

            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            control.AddBrightnessChangeListener(screenManager);
            control.SetBightnessProvider(screenManager);
        }

        private void SetLightMeter(ILightMeter sensor, BrightnessAwareUserControl control)
        {
            if (sensor == null)
            {
                throw new ArgumentNullException(nameof(sensor));
            }

            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            control.SetLightMeter(sensor);
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
