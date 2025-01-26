using Avalonia;
using Avalonia.Controls;

namespace GrblExpress.Controls;

public partial class CoolantControl : UserControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<CoolantControl, string>(nameof(Title), defaultValue: "Coolant");

    // Values
    public static readonly StyledProperty<bool> FloodProperty = AvaloniaProperty.Register<CoolantControl, bool>(nameof(Flood), defaultValue: false);
    public static readonly StyledProperty<bool> MistProperty = AvaloniaProperty.Register<CoolantControl, bool>(nameof(Mist), defaultValue: false);

    // Visibility
    public static readonly StyledProperty<bool> FloodVisibleProperty = AvaloniaProperty.Register<CoolantControl, bool>(nameof(FloodVisible), defaultValue: true);
    public static readonly StyledProperty<bool> MistVisibleProperty = AvaloniaProperty.Register<CoolantControl, bool>(nameof(MistVisible), defaultValue: true);

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public bool Flood
    {
        get => GetValue(FloodProperty);
        set => SetValue(FloodProperty, value);
    }

    public bool Mist
    {
        get => GetValue(MistProperty);
        set => SetValue(MistProperty, value);
    }

    public bool FloodVisible
    {
        get => GetValue(FloodVisibleProperty);
        set => SetValue(FloodVisibleProperty, value);
    }

    public bool MistVisible
    {
        get => GetValue(MistVisibleProperty);
        set => SetValue(MistVisibleProperty, value);
    }

    public CoolantControl()
    {
        DataContext = this;
        InitializeComponent();
    }
}