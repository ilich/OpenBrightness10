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
            lux.Text = value == null
                ? "not available"
                : value.ToString();
        }
    }
}
