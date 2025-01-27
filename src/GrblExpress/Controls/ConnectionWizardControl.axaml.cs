using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using GrblExpress.Common.Types;
using GrblExpress.Controls.ConnectionWizardControls;

namespace GrblExpress.Controls;

public partial class ConnectionWizardControl : UserControl
{
    public static readonly StyledProperty<ConnectionType> SelectedConnectionTypeProperty = AvaloniaProperty.Register<ConnectionWizardControl, ConnectionType>(nameof(SelectedConnectionType), defaultValue: ConnectionType.Serial);
    public static readonly StyledProperty<UserControl> CurrentStepControlProperty = AvaloniaProperty.Register<ConnectionWizardControl, UserControl>(nameof(CurrentStepControl));
    public static readonly StyledProperty<bool> Step2EnabledProperty = AvaloniaProperty.Register<ConnectionWizardControl, bool>(nameof(Step2Enabled), defaultValue: false);
    public static readonly StyledProperty<bool> Step3EnabledProperty = AvaloniaProperty.Register<ConnectionWizardControl, bool>(nameof(Step3Enabled), defaultValue: false);

    public ConnectionType SelectedConnectionType
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
        // TODO : Validate the current step before moving to the next step

        if (CurrentStepControl is ConnectionTypeSelectControl)
        {
            var validationResult = ((ConnectionTypeSelectControl)CurrentStepControl).Validate();
            if (!validationResult.HasError)
            {
                Step2Enabled = true;
                // TODO : Load the next step based on the selected connection type
                switch (SelectedConnectionType)
                {
                    case ConnectionType.Serial:
                        //CurrentStepControl = new Control();
                        break;
                    case ConnectionType.Telnet:
                        //CurrentStepControl = new Control();
                        break;
                    case ConnectionType.Websocket:
                        //CurrentStepControl = new Control();
                        break;
                    default:
                        // TODO : Show error message
                        break;
                }
            }
            else
            {
                // TODO : Show error message
            }

        }
        //else if (CurrentStepControl is SerialConnectionControl)
        //{
        //CurrentStepControl = new SerialConnectionControl();
        //}
    }

    private void Step1_HyperlinkButton_Click(object? sender, RoutedEventArgs e)
    {
        CurrentStepControl = new ConnectionTypeSelectControl();
    }
}