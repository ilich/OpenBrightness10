using OpenBrightness10.Devices;
using System.Windows.Forms;

namespace OpenBrightness10
{
    partial class Main : Form
    {
        private readonly IScreenManager screenManager = new ScreenManager();

        private readonly IComputerManager computerManager = new ComputerManager();

        public Main()
        {
            InitializeComponent();
            SetScreenManager(screenManager);
            SetCompyterManager(computerManager);
        }

        private void SetCompyterManager(IComputerManager computerManager)
        {
            if (computerManager == null)
            {
                return;
            }

            lockPC.ComputerManager = computerManager;
        }

        private void SetScreenManager(IScreenManager screenManager)
        {
            if (screenManager == null)
            {
                return;
            }

            displayBrightness.ScreenManager = screenManager;
            setBrightness.ScreenManager = screenManager;
        }

        private void OnLoad(object sender, System.EventArgs e)
        {
            screenManager.Start();
        }
    }
}
