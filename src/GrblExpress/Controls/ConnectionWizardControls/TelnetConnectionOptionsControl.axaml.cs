using Avalonia.Controls;

namespace GrblExpress.Controls.ConnectionWizardControls;

public partial class TelnetConnectionOptionsControl : UserControl
{
    public TelnetConnectionOptionsControl()
    {
        DataContext = this;
        InitializeComponent();
    }
}