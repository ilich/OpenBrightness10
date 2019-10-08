using System;
using OpenBrightness10.Devices;

namespace OpenBrightness10.Controls
{
    internal partial class SensorManager : BrightnessAwareUserControl
    {
        public SensorManager()
        {
            this.InitializeComponent();
        }

        public override void SetLightMeter(ILightMeter lightMeter)
        {
            if (this.LightMeter != null)
            {
                LightMeter.IsOnlineChanged -= this.OnSensorStatusChanged;
                LightMeter.EnabledChanged -= this.OnSensorEnabledChanged;
            }

            base.SetLightMeter(lightMeter);
            LightMeter.IsOnlineChanged += this.OnSensorStatusChanged;
            LightMeter.EnabledChanged += this.OnSensorEnabledChanged;
            this.ShowSensorInfo();
        }

        private void OnSensorStatusChanged(object sender, bool isOnline)
        {
            this.Invoke(new Action(() => this.ShowSensorInfo()));
        }

        private void OnSensorEnabledChanged(object sender, bool isEnabled)
        {
            this.Invoke(new Action(() => this.sensorEnabled.Checked = isEnabled));
        }

        private void OnSensorEnabledCheckedChanged(object sender, EventArgs e)
        {
            LightMeter.Enabled = this.sensorEnabled.Checked;
        }

        private void ShowSensorInfo()
        {
            this.sensorName.Text = LightMeter?.Name ?? SensorMessages.Offline;
            this.sensorEnabled.Enabled = LightMeter?.IsOnline == true;
        }
    }
}
