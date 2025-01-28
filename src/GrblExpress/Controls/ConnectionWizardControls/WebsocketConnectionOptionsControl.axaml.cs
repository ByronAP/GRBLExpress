using Avalonia.Controls;

namespace GrblExpress.Controls.ConnectionWizardControls;

public partial class WebsocketConnectionOptionsControl : UserControl
{
    public WebsocketConnectionOptionsControl()
    {
        DataContext = this;
        InitializeComponent();
    }
}