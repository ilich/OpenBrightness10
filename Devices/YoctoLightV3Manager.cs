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

        private readonly Thread workingThread;

        private readonly ManualResetEvent resetEvent = new ManualResetEvent(false);

        private bool disposedValue = false; // To detect redundant calls

        private YLightSensor sensor;

        private int lastBrightness;

        private int lastLux;

        private bool enabled;

        public YoctoLightV3Manager()
        {
            string errorMsg = string.Empty;
            if (YAPI.RegisterHub("usb", ref errorMsg) != YAPI.SUCCESS)
            {
                throw new InvalidOperationException(errorMsg);
            }

            YAPI.RegisterDeviceArrivalCallback(this.OnDeviceConnected);
            YAPI.RegisterDeviceRemovalCallback(this.OnDeviceDisconnected);

            this.workingThread = new Thread(this.RunSensorLoop)
            {
                IsBackground = true
            };
            this.workingThread.Start();
        }

        ~YoctoLightV3Manager()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(false);
        }

        public event EventHandler<int> LuxChanged;

        public event EventHandler<bool> IsOnlineChanged;

        public event EventHandler<bool> EnabledChanged;

        public event EventHandler<int> BrightnessChanged;

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }

            set
            {
                if (value)
                {
                    this.Start();
                }
                else
                {
                    this.Stop();
                }

                this.enabled = value;
                this.EnabledChanged?.Invoke(this, this.enabled);
            }
        }

        public int? Brightness
        {
            get
            {
                return this.IsOnline
                    ? this.CalculateBrightness(this.sensor.get_currentValue())
                    : (int?)null;
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        public int? Lux => this.IsOnline
           ? (int?)Math.Round(this.sensor.get_currentValue())
           : null;

        public string Name => this.sensor?.get_friendlyName();

        public bool IsOnline => this.sensor?.isOnline() ?? false;
        
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Start()
        {
            this.CheckState();
            this.resetEvent.Set();
        }

        public void Stop()
        {
            this.CheckState();
            this.resetEvent.Reset();
            Interlocked.Exchange(ref this.lastLux, 0);
            Interlocked.Exchange(ref this.lastBrightness, 0);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.resetEvent.Dispose();
                }

                YAPI.FreeAPI();
                this.disposedValue = true;
            }
        }

        private void RunSensorLoop()
        {
            this.resetEvent.WaitOne();

            string errorMsg = string.Empty;
            while (true)
            {
                this.resetEvent.WaitOne();
                YAPI.UpdateDeviceList(ref errorMsg);

                int? current = this.Brightness;
                if (current >= 0 && current != this.lastBrightness)
                {
                    Interlocked.Exchange(ref this.lastBrightness, (int)current);
                    this.BrightnessChanged?.Invoke(this, (int)current);
                }

                int? currentLux = this.Lux;
                if (currentLux >= 0 && currentLux != this.lastLux)
                {
                    Interlocked.Exchange(ref this.lastLux, (int)currentLux);
                    this.LuxChanged?.Invoke(this, (int)currentLux);
                }

                YAPI.Sleep(Timeout, ref errorMsg);
            }
        }

        private void OnDeviceConnected(YModule module)
        {
            var found = YLightSensor.FirstLightSensor();
            Interlocked.Exchange(ref this.sensor, found);

            if (this.IsOnline)
            {
                this.IsOnlineChanged?.Invoke(this, true);
                this.EnabledChanged?.Invoke(this, this.Enabled);
            }
        }

        private void OnDeviceDisconnected(YModule module)
        {
            Interlocked.Exchange(ref this.sensor, null);
            Interlocked.Exchange(ref this.lastLux, 0);
            Interlocked.Exchange(ref this.lastBrightness, 0);
            this.IsOnlineChanged?.Invoke(this, false);
        }

        private int CalculateBrightness(double lux)
        {
            // https://www.maximintegrated.com/en/design/technical-documents/app-notes/4/4913.html
            double brightness = lux >= 1254
                ? 100.0
                : (9.932 * Math.Log(lux)) + 27.059;

            return (int)Math.Round(brightness);
        }

        private void CheckState()
        {
            if (this.disposedValue)
            {
                throw new ObjectDisposedException("YoctoLightV3Manager");
            }
        }
    }
}
