using OpenBrightness10.Devices;

namespace OpenBrightness10.Controls
{
    interface IScreenManagerAware
    {
        IScreenManager ScreenManager { get; set; }
    }
}
