using System;

namespace OpenBrightness10.Devices
{
    interface ILightMeter
    {
        int? Lux { get; }

        string Name { get; }

        bool IsOnline { get; }

        bool Enabled { get; }

        event EventHandler<int> LuxChanged;

        event EventHandler<bool> IsOnlineChanged;
    }
}
