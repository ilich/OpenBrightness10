using System.Runtime.InteropServices;

namespace OpenBrightness10.Devices
{
    class ComputerManager : IComputerManager
    {
        [DllImport("user32")]
        private static extern void LockWorkStation();

        public void LockComputer()
        {
            LockWorkStation();
        }
    }
}
