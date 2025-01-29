using Avalonia;
using Avalonia.Controls;
using GrblExpress.Common.Interfaces;
using GrblExpress.Common.Objects;
using GrblExpress.Common.Types;
using System;
using System.IO.Ports;
using System.Linq;

namespace GrblExpress.Controls.ConnectionWizardControls;

public partial class SerialConnectionOptionsControl : UserControl
{
    public static readonly StyledProperty<ISerialPortOptions> SerialPortOptionsProperty =
        AvaloniaProperty.Register<SerialConnectionOptionsControl, ISerialPortOptions>(nameof(SerialPortOptions));

    public ISerialPortOptions SerialPortOptions
    {
        get => GetValue(SerialPortOptionsProperty);
        set => SetValue(SerialPortOptionsProperty, value);
    }

    public string[] AvailablePortNames => SerialPortHelpers.ListAvailablePorts();
    public BaudRate[] AvailableBaudRates => [.. Enum.GetValues<BaudRate>().Where(br => br != BaudRate.None)];
    public DataBits[] AvailableDataBits => Enum.GetValues<DataBits>();
    public Parity[] AvailableParities => Enum.GetValues<Parity>();
    public StopBits[] AvailableStopBits => Enum.GetValues<StopBits>();
    public Handshake[] AvailableHandshakes => Enum.GetValues<Handshake>();
    public DeviceResetMode[] AvailableResetModes => Enum.GetValues<DeviceResetMode>();

    public SerialConnectionOptionsControl()
    {
        InitializeComponent();
        SerialPortOptions = new SerialPortOptions();
        DataContext = this;
    }
}
