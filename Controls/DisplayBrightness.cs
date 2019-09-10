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
            if (ScreenManager == null)
            {
                UpdateBrightness(null);
            }
            else
            {
                UpdateBrightness(ScreenManager.Brightness);
            }
        }

        private void UpdateBrightness(int? value)
        {
            if (ScreenManager == null)
            {
                brightness.Text = "Invalid brightness";
            }
            else
            {
                brightness.Text = $"{value}%";
            }
        }
    }
}
