using System;

namespace OpenBrightness10.Devices
{
    internal interface ILightMeter
    {
        event EventHandler<int> LuxChanged;

        event EventHandler<bool> IsOnlineChanged;

        event EventHandler<bool> EnabledChanged;

        int? Lux { get; }

        string Name { get; }

        bool IsOnline { get; }

        bool Enabled { get; set; }
    }
}
