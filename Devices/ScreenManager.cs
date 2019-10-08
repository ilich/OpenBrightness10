using System;
using System.Management;

namespace OpenBrightness10.Devices
{
    class ScreenManager 
        : IBrightness,
        IBrightnessChangeListener,
        IDisposable
    {
        private readonly ManagementScope scope = new ManagementScope("root\\WMI");

        private readonly SelectQuery brightnessQuery =
            new SelectQuery("SELECT * FROM WmiMonitorBrightness");

        private readonly ManagementEventWatcher brightnessWatcher;

        private bool disposedValue = false;

        public ScreenManager()
        {
            var eventQuery = new EventQuery(
                @"SELECT * FROM __InstanceOperationEvent WITHIN 1 WHERE TargetInstance ISA ""WmiMonitorBrightness""");
            brightnessWatcher = new ManagementEventWatcher(scope, eventQuery);
            brightnessWatcher.EventArrived += OnWmiMonitorBrightnessChanged;
        }

        public int Brightness
        {
            get => GetBrightness();
            set
            {
                SetBrightness(value);
            }
        }

        public int? Lux => null;

        public event EventHandler<int> BrightnessChanged;

        public void Start()
        {
            CheckState();
            brightnessWatcher.Start();
        }

        public void Stop()
        {
            CheckState();
            brightnessWatcher.Stop();
        }

        private void OnWmiMonitorBrightnessChanged(object sender, EventArrivedEventArgs e)
        {
            if (!disposedValue)
            {
                BrightnessChanged?.Invoke(this, Brightness);
            }
        }

        private int GetBrightness()
        {
            CheckState();

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, brightnessQuery))
            {
                using (ManagementObjectCollection objectCollection = searcher.Get())
                {
                    var resultEnum = objectCollection.GetEnumerator();
                    resultEnum.MoveNext();
                    var brightnessClass = resultEnum.Current;
                    int brightness = int.Parse(brightnessClass.GetPropertyValue("CurrentBrightness").ToString());
                    return brightness;
                }
            }
        }

        private void SetBrightness(int value)
        {
            CheckState();

            if (value < 0)
            {
                value = 0;
            }
            else if (value > 100)
            {
                value = 100;
            }

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, brightnessQuery))
            {
                using (ManagementObjectCollection objectCollection = searcher.Get())
                {
                    var resultEnum = objectCollection.GetEnumerator();
                    resultEnum.MoveNext();
                    var brightnessClass = resultEnum.Current;

                    // We need to create an instance to use the Set method
                    var instanceName = (string)brightnessClass["InstanceName"];
                    var instance = new ManagementObject(
                        "root\\WMI",
                        $"WmiMonitorBrightnessMethods.InstanceName='{instanceName}'",
                        null);

                    var inParams = instance.GetMethodParameters("WmiSetBrightness");
                    inParams["Brightness"] = value;
                    inParams["Timeout"] = 0;
                    instance.InvokeMethod("WmiSetBrightness", inParams, null);
                }
            }
        }

        private void CheckState()
        {
            if (disposedValue)
            {
                throw new InvalidOperationException();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    brightnessWatcher.Stop();
                    brightnessWatcher.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
