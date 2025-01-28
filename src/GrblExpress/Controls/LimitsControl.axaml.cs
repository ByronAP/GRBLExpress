using Avalonia;
using Avalonia.Controls;

namespace GrblExpress.Controls;

public partial class LimitsControl : UserControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<LimitsControl, string>(nameof(Title), defaultValue: "Program Limits");
    public static readonly StyledProperty<bool> ReadOnlyProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(ReadOnly), defaultValue: true);

    // Axis Min Values
    public static readonly StyledProperty<double> XMinProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(XMin), defaultValue: 0);
    public static readonly StyledProperty<double> YMinProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(YMin), defaultValue: 0);
    public static readonly StyledProperty<double> ZMinProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(ZMin), defaultValue: 0);
    public static readonly StyledProperty<double> AMinProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(AMin), defaultValue: 0);
    public static readonly StyledProperty<double> BMinProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(BMin), defaultValue: 0);
    public static readonly StyledProperty<double> CMinProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(CMin), defaultValue: 0);
    public static readonly StyledProperty<double> UMinProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(UMin), defaultValue: 0);
    public static readonly StyledProperty<double> VMinProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(VMin), defaultValue: 0);
    public static readonly StyledProperty<double> WMinProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(WMin), defaultValue: 0);

    // Axis Max Values
    public static readonly StyledProperty<double> XMaxProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(XMax), defaultValue: 0);
    public static readonly StyledProperty<double> YMaxProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(YMax), defaultValue: 0);
    public static readonly StyledProperty<double> ZMaxProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(ZMax), defaultValue: 0);
    public static readonly StyledProperty<double> AMaxProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(AMax), defaultValue: 0);
    public static readonly StyledProperty<double> BMaxProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(BMax), defaultValue: 0);
    public static readonly StyledProperty<double> CMaxProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(CMax), defaultValue: 0);
    public static readonly StyledProperty<double> UMaxProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(UMax), defaultValue: 0);
    public static readonly StyledProperty<double> VMaxProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(VMax), defaultValue: 0);
    public static readonly StyledProperty<double> WMaxProperty = AvaloniaProperty.Register<LimitsControl, double>(nameof(WMax), defaultValue: 0);

    // Axis Visibility
    public static readonly StyledProperty<bool> IsXVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(IsXVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsYVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(IsYVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsZVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(IsZVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsAVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(IsAVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsBVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(IsBVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsCVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(IsCVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsUVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(IsUVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsVVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(IsVVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsWVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(IsWVisible), defaultValue: true);

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public bool ReadOnly
    {
        get => GetValue(ReadOnlyProperty);
        set => SetValue(ReadOnlyProperty, value);
    }

    public double XMin
    {
        get => GetValue(XMinProperty);
        set => SetValue(XMinProperty, value);
    }

    public double YMin
    {
        get => GetValue(YMinProperty);
        set => SetValue(YMinProperty, value);
    }

    public double ZMin
    {
        get => GetValue(ZMinProperty);
        set => SetValue(ZMinProperty, value);
    }

    public double AMin
    {
        get => GetValue(AMinProperty);
        set => SetValue(AMinProperty, value);
    }

    public double BMin
    {
        get => GetValue(BMinProperty);
        set => SetValue(BMinProperty, value);
    }

    public double CMin
    {
        get => GetValue(CMinProperty);
        set => SetValue(CMinProperty, value);
    }

    public double UMin
    {
        get => GetValue(UMinProperty);
        set => SetValue(UMinProperty, value);
    }

    public double VMin
    {
        get => GetValue(VMinProperty);
        set => SetValue(VMinProperty, value);
    }

    public double WMin
    {
        get => GetValue(WMinProperty);
        set => SetValue(WMinProperty, value);
    }

    public double XMax
    {
        get => GetValue(XMaxProperty);
        set => SetValue(XMaxProperty, value);
    }

    public double YMax
    {
        get => GetValue(YMaxProperty);
        set => SetValue(YMaxProperty, value);
    }

    public double ZMax
    {
        get => GetValue(ZMaxProperty);
        set => SetValue(ZMaxProperty, value);
    }

    public double AMax
    {
        get => GetValue(AMaxProperty);
        set => SetValue(AMaxProperty, value);
    }

    public double BMax
    {
        get => GetValue(BMaxProperty);
        set => SetValue(BMaxProperty, value);
    }

    public double CMax
    {
        get => GetValue(CMaxProperty);
        set => SetValue(CMaxProperty, value);
    }

    public double UMax
    {
        get => GetValue(UMaxProperty);
        set => SetValue(UMaxProperty, value);
    }

    public double VMax
    {
        get => GetValue(VMaxProperty);
        set => SetValue(VMaxProperty, value);
    }

    public double WMax
    {
        get => GetValue(WMaxProperty);
        set => SetValue(WMaxProperty, value);
    }

    public bool IsXVisible
    {
        get => GetValue(IsXVisibleProperty);
        set => SetValue(IsXVisibleProperty, value);
    }

    public bool IsYVisible
    {
        get => GetValue(IsYVisibleProperty);
        set => SetValue(IsYVisibleProperty, value);
    }

    public bool IsZVisible
    {
        get => GetValue(IsZVisibleProperty);
        set => SetValue(IsZVisibleProperty, value);
    }

    public bool IsAVisible
    {
        get => GetValue(IsAVisibleProperty);
        set => SetValue(IsAVisibleProperty, value);
    }

    public bool IsBVisible
    {
        get => GetValue(IsBVisibleProperty);
        set => SetValue(IsBVisibleProperty, value);
    }

    public bool IsCVisible
    {
        get => GetValue(IsCVisibleProperty);
        set => SetValue(IsCVisibleProperty, value);
    }

    public bool IsUVisible
    {
        get => GetValue(IsUVisibleProperty);
        set => SetValue(IsUVisibleProperty, value);
    }

    public bool IsVVisible
    {
        get => GetValue(IsVVisibleProperty);
        set => SetValue(IsVVisibleProperty, value);
    }

    public bool IsWVisible
    {
        get => GetValue(IsWVisibleProperty);
        set => SetValue(IsWVisibleProperty, value);
    }

    public LimitsControl()
    {
        DataContext = this;
        InitializeComponent();
    }
}