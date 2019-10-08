using System.Collections.Generic;
using System.Windows.Forms;
using OpenBrightness10.Devices;

namespace OpenBrightness10.Controls
{
    abstract class BrightnessAwareUserControl : UserControl
    {
        protected List<IBrightnessChangeListener> BrightnessChangeListeners { get; } =
            new List<IBrightnessChangeListener>();

        protected IBrightness BrightnessProvider { get; set; }

        protected ILightMeter LightMeter { get; set; }

        public abstract void AddBrightnessChangeListener(IBrightnessChangeListener listener);

        public abstract void RemoveBrightnessChangeListener(IBrightnessChangeListener listener);

        public virtual void SetBightnessProvider(IBrightness brightnessProvider)
        {
            BrightnessProvider = brightnessProvider;
        }

        public virtual void SetLightMeter(ILightMeter lightMeter)
        {
            LightMeter = lightMeter;
        }
    }
}
