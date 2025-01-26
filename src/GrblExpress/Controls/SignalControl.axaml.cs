using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace GrblExpress.Controls;

public partial class SignalControl : UserControl
{
    public static readonly StyledProperty<IBrush> ActiveBrushProperty = AvaloniaProperty.Register<SignalControl, IBrush>(nameof(ActiveBrush), defaultValue: new SolidColorBrush(Colors.DarkRed));
    public static readonly StyledProperty<bool> IsActiveProperty = AvaloniaProperty.Register<SignalControl, bool>(nameof(IsActive), defaultValue: false);
    public static readonly StyledProperty<string> TextProperty = AvaloniaProperty.Register<SignalControl, string>(nameof(Text), defaultValue: "?");
    public static readonly StyledProperty<string> ToolTipTextProperty = AvaloniaProperty.Register<SignalControl, string>(nameof(ToolTipText), defaultValue: "?");

    public IBrush ActiveBrush
    {
        get => GetValue(ActiveBrushProperty);
        set => SetValue(ActiveBrushProperty, value);
    }

    public bool IsActive
    {
        get => GetValue(IsActiveProperty);
        set
        {
            CtrlBorder.Background = value ? ActiveBrush : new SolidColorBrush(Colors.Transparent);
            SetValue(IsActiveProperty, value);
        }
    }

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string ToolTipText
    {
        get => GetValue(ToolTipTextProperty);
        set => SetValue(ToolTipTextProperty, value);
    }

    public SignalControl()
    {
        InitializeComponent();
    }
}
