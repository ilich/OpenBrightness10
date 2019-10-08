using OpenBrightness10.Devices;
using System;
using System.Windows.Forms;

namespace OpenBrightness10.Controls
{
    partial class SetBrightness : BrightnessAwareUserControl
    {
        private int initialBrightnessValue;

        public SetBrightness()
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
            if (brightness.Value == current)
            {
                return;
            }

            brightness.Value = current;
            
            // if brightness change has been required by light sensor, let's
            // change system's brightness
            if (sender is ILightMeter && 
                BrightnessProvider != null && 
                brightness.Value != initialBrightnessValue)
            {
                BrightnessProvider.Brightness = current;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            brightness.Value = BrightnessProvider?.Brightness ?? 0;
        }

        private void OnBrightnessMouseUp(object sender, MouseEventArgs e)
        {
            if (BrightnessProvider != null && brightness.Value != initialBrightnessValue)
            {
                BrightnessProvider.Brightness = brightness.Value;
            }
        }

        private void OnBrightnessMouseDown(object sender, MouseEventArgs e)
        {
            initialBrightnessValue = brightness.Value;
        }
    }
}
