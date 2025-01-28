using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using GrblExpress.Common.Types;
using GrblExpress.Controls.ConnectionWizardControls;

namespace GrblExpress.Controls;

public partial class ConnectionWizardControl : UserControl
{
    public static readonly StyledProperty<ConnectionType?> SelectedConnectionTypeProperty = AvaloniaProperty.Register<ConnectionWizardControl, ConnectionType?>(nameof(SelectedConnectionType), defaultValue: ConnectionType.Serial);
    public static readonly StyledProperty<UserControl> CurrentStepControlProperty = AvaloniaProperty.Register<ConnectionWizardControl, UserControl>(nameof(CurrentStepControl));
    public static readonly StyledProperty<bool> Step2EnabledProperty = AvaloniaProperty.Register<ConnectionWizardControl, bool>(nameof(Step2Enabled), defaultValue: false);
    public static readonly StyledProperty<bool> Step3EnabledProperty = AvaloniaProperty.Register<ConnectionWizardControl, bool>(nameof(Step3Enabled), defaultValue: false);

    public ConnectionType? SelectedConnectionType
    {
        get => GetValue(SelectedConnectionTypeProperty);
        set => SetValue(SelectedConnectionTypeProperty, value);
    }

    public UserControl CurrentStepControl
    {
        get => GetValue(CurrentStepControlProperty);
        set => SetValue(CurrentStepControlProperty, value);
    }

    public bool Step2Enabled
    {
        get => GetValue(Step2EnabledProperty);
        set => SetValue(Step2EnabledProperty, value);
    }

    public bool Step3Enabled
    {
        get => GetValue(Step3EnabledProperty);
        set => SetValue(Step3EnabledProperty, value);
    }

    public ConnectionWizardControl()
    {
        DataContext = this;
        CurrentStepControl = new ConnectionTypeSelectControl();
        InitializeComponent();
    }

    private void Next_Button_Click(object? sender, RoutedEventArgs e)
    {
        ErrorInfoBar.IsOpen = false;

        if (CurrentStepControl is ConnectionTypeSelectControl)
        {
            // Validate the current step before moving to the next step
            var validationResult = ((ConnectionTypeSelectControl)CurrentStepControl).Validate();
            if (!validationResult.HasError)
            {
                SelectedConnectionType = ((ConnectionTypeSelectControl)CurrentStepControl).SelectedConnectionType;
                Step2Enabled = true;
                // Load the next step based on the selected connection type
                CurrentStepControl = GetStep2Control();

            }
            else
            {
                ShowError(validationResult.ErrorMsg);
            }

        }
        //else if (CurrentStepControl is SerialConnectionControl)
        //{
        //CurrentStepControl = new SerialConnectionControl();
        //}
    }

    private UserControl GetStep2Control()
    {
        switch (SelectedConnectionType)
        {
            case ConnectionType.Serial:
                return new SerialConnectionOptionsControl();
            case ConnectionType.Telnet:
                return new TelnetConnectionOptionsControl();
            case ConnectionType.Websocket:
                return new WebsocketConnectionOptionsControl();
            default:
                Step2Enabled = false;
                Step3Enabled = false;
                return new ConnectionTypeSelectControl();
        }
    }

    private void ShowError(string message)
    {
        ErrorInfoBar.Message = message;
        ErrorInfoBar.IsOpen = true;
    }

    private void Step1_HyperlinkButton_Click(object? sender, RoutedEventArgs e)
    {
        if (CurrentStepControl is ConnectionTypeSelectControl) return;

        SelectedConnectionType = null;
        Step2Enabled = false;
        Step3Enabled = false;

        CurrentStepControl = new ConnectionTypeSelectControl();
    }

    private void Step2_HyperlinkButton_Click(object? sender, RoutedEventArgs e)
    {
        if (CurrentStepControl is SerialConnectionOptionsControl ||
            CurrentStepControl is TelnetConnectionOptionsControl ||
            CurrentStepControl is WebsocketConnectionOptionsControl) return;

        Step2Enabled = true;
        Step3Enabled = false;

        CurrentStepControl = GetStep2Control();
    }
}