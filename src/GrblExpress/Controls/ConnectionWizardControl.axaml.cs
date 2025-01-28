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
    public static readonly StyledProperty<bool> IsStep2EnabledProperty = AvaloniaProperty.Register<ConnectionWizardControl, bool>(nameof(IsStep2Enabled), defaultValue: false);
    public static readonly StyledProperty<bool> IsStep3EnabledProperty = AvaloniaProperty.Register<ConnectionWizardControl, bool>(nameof(IsStep3Enabled), defaultValue: false);

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

    public bool IsStep2Enabled
    {
        get => GetValue(IsStep2EnabledProperty);
        set => SetValue(IsStep2EnabledProperty, value);
    }

    public bool IsStep3Enabled
    {
        get => GetValue(IsStep3EnabledProperty);
        set => SetValue(IsStep3EnabledProperty, value);
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
                IsStep2Enabled = true;
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
                IsStep2Enabled = false;
                IsStep3Enabled = false;
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
        IsStep2Enabled = false;
        IsStep3Enabled = false;

        CurrentStepControl = new ConnectionTypeSelectControl();
    }

    private void Step2_HyperlinkButton_Click(object? sender, RoutedEventArgs e)
    {
        if (CurrentStepControl is SerialConnectionOptionsControl ||
            CurrentStepControl is TelnetConnectionOptionsControl ||
            CurrentStepControl is WebsocketConnectionOptionsControl) return;

        IsStep2Enabled = true;
        IsStep3Enabled = false;

        CurrentStepControl = GetStep2Control();
    }
}