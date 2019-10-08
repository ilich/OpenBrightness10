using System;
using System.Threading;

namespace OpenBrightness10.Devices
{
    public class YoctoLightV3Manager
        : IBrightness,
        IBrightnessChangeListener,
        ILightMeter,
        IDisposable
    {
        private const int Timeout = 2000;

        private YLightSensor sensor;

        private readonly Thread workingThread;

        private readonly ManualResetEvent resetEvent = new ManualResetEvent(false);

        private int lastBrightness;

        private int lastLux;

        public int? Brightness
        {
            get
            {
                return IsOnline
                    ? CalculateBrightness(sensor.get_currentValue())
                    : (int?)null;
            }
            set
            {
                throw new NotSupportedException();
            }
        }    

        public int? Lux => IsOnline
            ? (int?)Math.Round(sensor.get_currentValue())
            : null;

        public string Name => sensor?.get_friendlyName();

        public bool IsOnline => sensor?.isOnline() ?? false;

        private bool enabled;
        public bool Enabled
        {
            get { return enabled; }
            set
            {
                if (value)
                {
                    Start();
                }
                else
                {
                    Stop();
                }

                enabled = value;
            }
        }

        public event EventHandler<int> BrightnessChanged;

        public event EventHandler<int> LuxChanged;

        public event EventHandler<bool> IsOnlineChanged;

        public YoctoLightV3Manager()
        {
            string errorMsg = string.Empty;
            if (YAPI.RegisterHub("usb", ref errorMsg) != YAPI.SUCCESS)
            {
                throw new InvalidOperationException(errorMsg);
            }

            YAPI.RegisterDeviceArrivalCallback(OnDeviceConnected);
            YAPI.RegisterDeviceRemovalCallback(OnDeviceDisconnected);

            workingThread = new Thread(RunSensorLoop)
            {
                IsBackground = true
            };
            workingThread.Start();
        }

        public void Start()
        {
            if (disposedValue)
            {
                throw new ObjectDisposedException("YoctoLightV3Manager");
            }

            resetEvent.Set();
        }

        public void Stop()
        {
            if (disposedValue)
            {
                throw new ObjectDisposedException("YoctoLightV3Manager");
            }

            resetEvent.Reset();
        }

        public void RunSensorLoop()
        {
            resetEvent.WaitOne();

            string errorMsg = string.Empty;
            while (true)
            {
                resetEvent.WaitOne();
                YAPI.UpdateDeviceList(ref errorMsg);

                int? current = Brightness;
                if (current >= 0 && current != lastBrightness)
                {
                    Interlocked.Exchange(ref lastBrightness, (int)current);
                    BrightnessChanged?.Invoke(this, (int)current);
                }

                int? currentLux = Lux;
                if (currentLux >= 0 && currentLux != lastLux)
                {
                    Interlocked.Exchange(ref lastLux, (int)currentLux);
                    LuxChanged?.Invoke(this, (int)currentLux);
                }

                YAPI.Sleep(Timeout, ref errorMsg);
            }
        }

        private void OnDeviceConnected(YModule module)
        {
            var found = YLightSensor.FirstLightSensor();
            Interlocked.Exchange(ref sensor, found);

            if (IsOnline)
            {
                IsOnlineChanged?.Invoke(this, true);
            }
        }

        private void OnDeviceDisconnected(YModule module)
        {
            Interlocked.Exchange(ref sensor, null);
            IsOnlineChanged?.Invoke(this, false);
        }

        private int CalculateBrightness(double lux)
        {
            // https://www.maximintegrated.com/en/design/technical-documents/app-notes/4/4913.html
            double brightness = lux >= 1254
                ? 100.0
                : 9.932 * Math.Log(lux) + 27.059;

            return (int)Math.Round(brightness);
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    resetEvent.Dispose();
                }

                YAPI.FreeAPI();
                disposedValue = true;
            }
        }

        ~YoctoLightV3Manager()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
