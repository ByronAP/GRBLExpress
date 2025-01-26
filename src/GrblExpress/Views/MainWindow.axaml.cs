using Avalonia.Controls;
using GrblExpress.Common.Types;
using System.Diagnostics;

namespace GrblExpress.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void HomingControl_AxisHomingRequested(object sender, GenericCommand command)
        {
            // Send a homing command to the Grbl device
            Debug.Print($"Homing requested for axis {command}");
        }

        public void JoggingControl_JogRequested(object sender, (GenericCommand command, double distance, int feedrate) e)
        {
            // Send a jogging command to the Grbl device
            Debug.Print($"Jogging requested with command {e.command}, distance {e.distance}, feedrate {e.feedrate}");
        }

        public void CycleActionsControl_CycleCommandRequested(object sender, GenericCommand command)
        {
            // Send a cycle command to the Grbl device
            Debug.Print($"Cycle command requested with command {command}");
        }

        public void DroControl_ZeroCommandRequested(object sender, GenericCommand command)
        {
            // Send a zero command to the Grbl device
            Debug.Print($"Zero command requested with command {command}");
        }

        public void MdiControl_MdiCommandRequested(object sender, string command)
        {
            // Send an MDI command to the Grbl device
            Debug.Print($"MDI command requested with command {command}");
        }
    }
}