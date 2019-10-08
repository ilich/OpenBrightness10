using System;
using OpenBrightness10.Devices;

namespace OpenBrightness10.Controls
{
    internal partial class DisplayBrightness : BrightnessAwareUserControl
    {
        public DisplayBrightness()
        {
            this.InitializeComponent();
        }

        public override void AddBrightnessChangeListener(IBrightnessChangeListener listener)
        {
            if (BrightnessChangeListeners.Contains(listener))
            {
                return;
            }

            listener.BrightnessChanged += this.OnBrightnessChanged;
            BrightnessChangeListeners.Add(listener);
        }

        public override void RemoveBrightnessChangeListener(IBrightnessChangeListener listener)
        {
            if (!BrightnessChangeListeners.Contains(listener))
            {
                return;
            }

            listener.BrightnessChanged -= this.OnBrightnessChanged;
            BrightnessChangeListeners.Remove(listener);
        }

        public override void SetLightMeter(ILightMeter lightMeter)
        {
            if (this.LightMeter != null)
            {
                LightMeter.LuxChanged -= this.OnLuxChanged;
                LightMeter.IsOnlineChanged -= this.OnSensorStatusChanged;
                LightMeter.EnabledChanged -= this.OnSensorEnabledChanged;
            }

            base.SetLightMeter(lightMeter);
            LightMeter.LuxChanged += this.OnLuxChanged;
            LightMeter.IsOnlineChanged += this.OnSensorStatusChanged;
            LightMeter.EnabledChanged += this.OnSensorEnabledChanged;
        }

        private void OnSensorEnabledChanged(object sender, bool e)
        {
            this.Invoke(new Action(() => this.UpdateLux(null)));
        }

        private void OnSensorStatusChanged(object sender, bool isOnline)
        {
            this.Invoke(new Action(() => this.UpdateLux(null)));
        }

        private void OnLuxChanged(object sender, int lux)
        {
            this.Invoke(new Action(() => this.UpdateLux(lux)));
        }

        private void OnBrightnessChanged(object sender, int current)
        {
            this.Invoke(new Action(() => this.UpdateBrightness(current)));
        }

        private void OnLoad(object sender, EventArgs e)
        {
            this.UpdateBrightness(BrightnessProvider?.Brightness);
            this.UpdateLux(LightMeter?.Lux);
        }

        private void UpdateBrightness(int? value)
        {
            this.brightness.Text = value == null
                ? "not available"
                : $"{value}%";
        }

        private void UpdateLux(int? value)
        {
            if (LightMeter?.IsOnline == true && LightMeter?.Enabled == true)
            {
                this.lux.Text = value == null
                   ? SensorMessages.Offline
                   : $"{value} lux";
            }
            else if (LightMeter?.IsOnline == true && LightMeter?.Enabled == false)
            {
                this.lux.Text = SensorMessages.Disabled;
            }
            else
            {
                this.lux.Text = SensorMessages.Offline;
            }
        }
    }
}
