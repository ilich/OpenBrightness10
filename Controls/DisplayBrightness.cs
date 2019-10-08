using System;
using OpenBrightness10.Devices;

namespace OpenBrightness10.Controls
{
    partial class DisplayBrightness : BrightnessAwareUserControl
    {
        public DisplayBrightness()
        {
            InitializeComponent();
        }

        public override void AddBrightnessChangeListener(IBrightnessChangeListener listener)
        {
            if (BrightnessChangeListeners.Contains(listener))
            {
                return;
            }

            listener.BrightnessChanged += OnBrightnessChanged;
            BrightnessChangeListeners.Add(listener);
        }

        public override void RemoveBrightnessChangeListener(IBrightnessChangeListener listener)
        {
            if (!BrightnessChangeListeners.Contains(listener))
            {
                return;
            }

            listener.BrightnessChanged -= OnBrightnessChanged;
            BrightnessChangeListeners.Remove(listener);
        }

        public override void SetLightMeter(ILightMeter lightMeter)
        {
            if (LightMeter != null)
            {
                LightMeter.LuxChanged -= OnLuxChanged;
                LightMeter.IsOnlineChanged -= OnSensorStatusChanged;
                LightMeter.EnabledChanged -= OnSensorEnabledChanged;
            }

            base.SetLightMeter(lightMeter);
            LightMeter.LuxChanged += OnLuxChanged;
            LightMeter.IsOnlineChanged += OnSensorStatusChanged;
            LightMeter.EnabledChanged += OnSensorEnabledChanged;
        }

        private void OnSensorEnabledChanged(object sender, bool e)
        {
            Invoke(new Action(() => UpdateLux(null)));
        }

        private void OnSensorStatusChanged(object sender, bool isOnline)
        {
            Invoke(new Action(() => UpdateLux(null)));
        }

        private void OnLuxChanged(object sender, int lux)
        {
            Invoke(new Action(() => UpdateLux(lux)));
        }

        private void OnBrightnessChanged(object sender, int current)
        {
            Invoke(new Action(() => UpdateBrightness(current)));
        }

        private void OnLoad(object sender, EventArgs e)
        {
            UpdateBrightness(BrightnessProvider?.Brightness);
            UpdateLux(LightMeter?.Lux);
        }

        private void UpdateBrightness(int? value)
        {
            brightness.Text = value == null
                ? "not available"
                : $"{value}%";
        }

        private void UpdateLux(int? value)
        {
            if (LightMeter?.IsOnline == true && LightMeter?.Enabled == true)
            {
                lux.Text = value == null
                   ? SensorMessages.Offline
                   : $"{value} lux";
            }
            else if (LightMeter?.IsOnline == true && LightMeter?.Enabled == false)
            {
                lux.Text = SensorMessages.Disabled;
            }
            else
            {
                lux.Text = SensorMessages.Offline;
            }
        }
    }
}
