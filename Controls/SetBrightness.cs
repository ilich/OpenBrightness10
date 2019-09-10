using OpenBrightness10.Devices;
using System;
using System.Windows.Forms;

namespace OpenBrightness10.Controls
{
    partial class SetBrightness : UserControl, IScreenManagerAware
    {
        private IScreenManager screenManager;

        private int initialBrightnessValue;

        public SetBrightness()
        {
            InitializeComponent();
        }

        public IScreenManager ScreenManager
        {
            get => screenManager;
            set
            {
                if (screenManager != null)
                {
                    screenManager.BrightnessChanged -= OnBrightnessChanged;
                }

                screenManager = value;
                if (screenManager != null)
                {
                    screenManager.BrightnessChanged += OnBrightnessChanged;
                }
            }
        }

        private void OnBrightnessChanged(object sender, int current)
        {
            if (brightness.Value == current)
            {
                return;
            }

            brightness.Value = current;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (ScreenManager != null)
            {
                brightness.Value = ScreenManager.Brightness;
            }
        }

        private void OnBrightnessMouseUp(object sender, MouseEventArgs e)
        {
            if (brightness.Value != initialBrightnessValue)
            {
                ScreenManager.Brightness = brightness.Value;
            }
        }

        private void OnBrightnessMouseDown(object sender, MouseEventArgs e)
        {
            initialBrightnessValue = brightness.Value;
        }
    }
}
