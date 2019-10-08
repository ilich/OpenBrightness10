using System;
using System.Windows.Forms;
using OpenBrightness10.Controls;
using OpenBrightness10.Devices;

namespace OpenBrightness10
{
    internal partial class Main : Form
    {
#pragma warning disable IDE0069 // Disposable fields should be disposed\
        // the fields are disposed within OnClose method
        private readonly ScreenManager screenManager = new ScreenManager();
        private readonly YoctoLightV3Manager lightSensor = new YoctoLightV3Manager();
#pragma warning restore IDE0069 // Disposable fields should be disposed

        public Main()
        {
            this.InitializeComponent();

            // setting up brightness manager via WMI
            this.SetScreenManager(this.screenManager, this.displayBrightness);
            this.SetScreenManager(this.screenManager, this.setBrightness);

            // setting up light sensor
            this.SetLightMeter(this.lightSensor, this.displayBrightness);
            this.SetLightMeter(this.lightSensor, this.sensorManager);
            this.setBrightness.AddBrightnessChangeListener(this.lightSensor);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (this.screenManager != null)
            {
                this.screenManager.Dispose();
            }

            if (this.lightSensor != null)
            {
                this.lightSensor.Dispose();
            }
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
            this.screenManager.Start();
            this.lightSensor.Enabled = true;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void OnNotifyIconDoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void OnMenuOpenClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void OnMenuExitClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
