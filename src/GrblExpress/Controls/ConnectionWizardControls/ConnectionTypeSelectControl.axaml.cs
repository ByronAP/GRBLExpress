using Avalonia;
using Avalonia.Controls;
using GrblExpress.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrblExpress.Controls.ConnectionWizardControls;

public partial class ConnectionTypeSelectControl : UserControl
{
    public static readonly StyledProperty<ConnectionType?> SelectedConnectionTypeProperty = AvaloniaProperty.Register<ConnectionWizardControl, ConnectionType?>(nameof(SelectedConnectionType), defaultValue: null);

    public IEnumerable<ConnectionType> AvailableConnectionTypes => Enum.GetValues(typeof(ConnectionType)).Cast<ConnectionType>();

    public ConnectionType? SelectedConnectionType
    {
        get => GetValue(SelectedConnectionTypeProperty);
        set => SetValue(SelectedConnectionTypeProperty, value);
    }

    public (bool HasError, string ErrorMsg) Validate()
    {
        if (!SelectedConnectionType.HasValue)
        {
            // TODO : Localize the error message
            return (false, "Please select a connection type");
        }
        return (true, "");
    }

    public ConnectionTypeSelectControl()
    {
        DataContext = this;
        InitializeComponent();
    }
}