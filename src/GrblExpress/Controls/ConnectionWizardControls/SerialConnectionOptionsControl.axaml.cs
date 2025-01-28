using Avalonia.Controls;

namespace GrblExpress.Controls.ConnectionWizardControls;

public partial class SerialConnectionOptionsControl : UserControl
{
    public SerialConnectionOptionsControl()
    {
        DataContext = this;
        InitializeComponent();
    }
}