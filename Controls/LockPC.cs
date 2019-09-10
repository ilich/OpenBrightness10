using OpenBrightness10.Devices;
using System;
using System.Windows.Forms;

namespace OpenBrightness10.Controls
{
    partial class LockPC : UserControl, IComputerManagerAware
    {
        public LockPC()
        {
            InitializeComponent();
        }

        public IComputerManager ComputerManager { get; set; }

        private void OnLockButtonClick(object sender, EventArgs e)
        {
            ComputerManager?.LockComputer();
        }
    }
}
