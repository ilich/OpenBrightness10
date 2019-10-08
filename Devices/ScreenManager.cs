using System;
using System.Management;

namespace OpenBrightness10.Devices
{
    internal class ScreenManager 
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
            this.brightnessWatcher = new ManagementEventWatcher(this.scope, eventQuery);
            this.brightnessWatcher.EventArrived += this.OnWmiMonitorBrightnessChanged;
        }

        public event EventHandler<int> BrightnessChanged;

        public int? Brightness
        {
            get => this.GetBrightness();
            set
            {
                this.SetBrightness(value ?? 100);
            }
        }

        public int? Lux => null;

        public void Start()
        {
            this.CheckState();
            this.brightnessWatcher.Start();
        }

        public void Stop()
        {
            this.CheckState();
            this.brightnessWatcher.Stop();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.brightnessWatcher.Stop();
                    this.brightnessWatcher.Dispose();
                }

                this.disposedValue = true;
            }
        }

        private void OnWmiMonitorBrightnessChanged(object sender, EventArrivedEventArgs e)
        {
            if (!this.disposedValue)
            {
                this.BrightnessChanged?.Invoke(this, this.Brightness ?? 100);
            }
        }

        private int GetBrightness()
        {
            this.CheckState();

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(this.scope, this.brightnessQuery))
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
            this.CheckState();

            if (value < 0)
            {
                value = 0;
            }
            else if (value > 100)
            {
                value = 100;
            }

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(this.scope, this.brightnessQuery))
            {
                using (ManagementObjectCollection objectCollection = searcher.Get())
                {
                    var resultEnum = objectCollection.GetEnumerator();
                    resultEnum.MoveNext();
                    var brightnessClass = resultEnum.Current;

                    // We need to create an instance to use the Set method
                    var instanceName = (string)brightnessClass["InstanceName"];
                    using (var instance = new ManagementObject(
                        "root\\WMI",
                        $"WmiMonitorBrightnessMethods.InstanceName='{instanceName}'",
                        null))
                    {
                        var inParams = instance.GetMethodParameters("WmiSetBrightness");
                        inParams["Brightness"] = value;
                        inParams["Timeout"] = 0;
                        instance.InvokeMethod("WmiSetBrightness", inParams, null);
                    }
                }
            }
        }

        private void CheckState()
        {
            if (this.disposedValue)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
