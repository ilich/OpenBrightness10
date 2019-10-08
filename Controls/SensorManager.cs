using System;
using OpenBrightness10.Devices;

namespace OpenBrightness10.Controls
{
    partial class SensorManager : BrightnessAwareUserControl
    {
        public SensorManager()
        {
            InitializeComponent();
        }

        public override void SetLightMeter(ILightMeter lightMeter)
        {
            if (LightMeter != null)
            {
                LightMeter.IsOnlineChanged -= OnSensorStatusChanged;
                LightMeter.EnabledChanged -= OnSensorEnabledChanged;
            }

            base.SetLightMeter(lightMeter);
            LightMeter.IsOnlineChanged += OnSensorStatusChanged;
            LightMeter.EnabledChanged += OnSensorEnabledChanged;
            ShowSensorInfo();
        }

        private void OnSensorStatusChanged(object sender, bool isOnline)
        {
            Invoke(new Action(() => ShowSensorInfo()));
        }

        private void OnSensorEnabledChanged(object sender, bool isEnabled)
        {
            Invoke(new Action(() => sensorEnabled.Checked = isEnabled));
        }

        private void OnSensorEnabledCheckedChanged(object sender, EventArgs e)
        {
            LightMeter.Enabled = sensorEnabled.Checked;
        }

        private void ShowSensorInfo()
        {
            sensorName.Text = LightMeter?.Name ?? SensorMessages.Offline;
            sensorEnabled.Enabled = LightMeter?.IsOnline == true;
        }
    }
}
