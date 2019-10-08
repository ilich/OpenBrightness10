using System;
using System.Windows.Forms;
using OpenBrightness10.Devices;

namespace OpenBrightness10.Controls
{
    internal partial class SetBrightness : BrightnessAwareUserControl
    {
        private int initialBrightnessValue;

        public SetBrightness()
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

        private void OnBrightnessChanged(object sender, int current)
        {
            if (this.brightness.Value == current)
            {
                return;
            }

            this.brightness.Value = current;
            
            // if brightness change has been required by light sensor, let's
            // change system's brightness
            if (sender is ILightMeter &&
                this.BrightnessProvider != null &&
                this.brightness.Value != this.initialBrightnessValue)
            {
                BrightnessProvider.Brightness = current;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            this.brightness.Value = BrightnessProvider?.Brightness ?? 0;
        }

        private void OnBrightnessMouseUp(object sender, MouseEventArgs e)
        {
            if (this.BrightnessProvider != null && this.brightness.Value != this.initialBrightnessValue)
            {
                BrightnessProvider.Brightness = this.brightness.Value;
            }
        }

        private void OnBrightnessMouseDown(object sender, MouseEventArgs e)
        {
            this.initialBrightnessValue = this.brightness.Value;
        }
    }
}
