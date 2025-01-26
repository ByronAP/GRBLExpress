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
    public static readonly StyledProperty<bool> XVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(XVisible), defaultValue: true);
    public static readonly StyledProperty<bool> YVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(YVisible), defaultValue: true);
    public static readonly StyledProperty<bool> ZVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(ZVisible), defaultValue: true);
    public static readonly StyledProperty<bool> AVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(AVisible), defaultValue: true);
    public static readonly StyledProperty<bool> BVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(BVisible), defaultValue: true);
    public static readonly StyledProperty<bool> CVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(CVisible), defaultValue: true);
    public static readonly StyledProperty<bool> UVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(UVisible), defaultValue: true);
    public static readonly StyledProperty<bool> VVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(VVisible), defaultValue: true);
    public static readonly StyledProperty<bool> WVisibleProperty = AvaloniaProperty.Register<LimitsControl, bool>(nameof(WVisible), defaultValue: true);

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

    public bool XVisible
    {
        get => GetValue(XVisibleProperty);
        set => SetValue(XVisibleProperty, value);
    }

    public bool YVisible
    {
        get => GetValue(YVisibleProperty);
        set => SetValue(YVisibleProperty, value);
    }

    public bool ZVisible
    {
        get => GetValue(ZVisibleProperty);
        set => SetValue(ZVisibleProperty, value);
    }

    public bool AVisible
    {
        get => GetValue(AVisibleProperty);
        set => SetValue(AVisibleProperty, value);
    }

    public bool BVisible
    {
        get => GetValue(BVisibleProperty);
        set => SetValue(BVisibleProperty, value);
    }

    public bool CVisible
    {
        get => GetValue(CVisibleProperty);
        set => SetValue(CVisibleProperty, value);
    }

    public bool UVisible
    {
        get => GetValue(UVisibleProperty);
        set => SetValue(UVisibleProperty, value);
    }

    public bool VVisible
    {
        get => GetValue(VVisibleProperty);
        set => SetValue(VVisibleProperty, value);
    }

    public bool WVisible
    {
        get => GetValue(WVisibleProperty);
        set => SetValue(WVisibleProperty, value);
    }

    public LimitsControl()
    {
        DataContext = this;
        InitializeComponent();
    }
}