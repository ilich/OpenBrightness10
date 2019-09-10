using System;

namespace OpenBrightness10.Devices
{
    interface IBrightnessChangeListener
    {
        void Start();

        void Stop();

        event EventHandler<int> BrightnessChanged;
    }
}
