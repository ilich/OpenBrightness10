using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBrightness10.Devices
{
    public class YoctoLightV3Manager
        : IBrightness,
        IBrightnessChangeListener,
        ILightMeter,
        IDisposable
    {
        public int Brightness { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int? Lux => throw new NotImplementedException();

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsOnline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<int> BrightnessChanged;

        public event EventHandler<int> LuxChanged;

        public event EventHandler<bool> IsOnlineChanged;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
