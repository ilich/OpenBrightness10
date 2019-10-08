using System;

namespace OpenBrightness10.Devices
{
    internal interface IBrightnessChangeListener
    {
        event EventHandler<int> BrightnessChanged;

        void Start();

        void Stop();
    }
}
