using System;

namespace OpenBrightness10.Devices
{
    interface ILightMeter
    {
        int? Lux { get; }

        string Name { get; set; }

        bool IsOnline { get; set; }

        event EventHandler<int> LuxChanged;

        event EventHandler<bool> IsOnlineChanged;
    }
}
