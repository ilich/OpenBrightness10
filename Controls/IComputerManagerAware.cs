using OpenBrightness10.Devices;

namespace OpenBrightness10.Controls
{
    interface IComputerManagerAware
    {
        IComputerManager ComputerManager { get; set; }
    }
}
