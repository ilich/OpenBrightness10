using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenBrightness10.Devices;

namespace OpenBrightness10.Controls
{
    // the class cannot be abstract because it will break UI Designer.
    internal class BrightnessAwareUserControl : UserControl
    {
        protected List<IBrightnessChangeListener> BrightnessChangeListeners { get; } =
            new List<IBrightnessChangeListener>();

        protected IBrightness BrightnessProvider { get; set; }

        protected ILightMeter LightMeter { get; set; }

        public virtual void AddBrightnessChangeListener(IBrightnessChangeListener listener)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveBrightnessChangeListener(IBrightnessChangeListener listener)
        {
            throw new NotImplementedException();
        }

        public virtual void SetBightnessProvider(IBrightness brightnessProvider)
        {
            this.BrightnessProvider = brightnessProvider;
        }

        public virtual void SetLightMeter(ILightMeter lightMeter)
        {
            this.LightMeter = lightMeter;
        }
    }
}
