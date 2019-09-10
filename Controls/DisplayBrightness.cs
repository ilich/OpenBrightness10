using OpenBrightness10.Devices;
using System;
using System.Windows.Forms;

namespace OpenBrightness10.Controls
{
    partial class DisplayBrightness : UserControl, IScreenManagerAware
    {
        private IScreenManager screenManager;

        public DisplayBrightness()
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
            Invoke(new Action(() => UpdateBrightness(current)));
        }

        private void OnLoad(object sender, EventArgs e)
        {
            UpdateBrightness(ScreenManager?.Brightness);
            UpdateLux(ScreenManager?.Lux);
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
