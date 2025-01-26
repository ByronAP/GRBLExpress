using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using GrblExpress.Common.Types;
using System;

namespace GrblExpress.Controls;

public partial class HomingControl : UserControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<HomingControl, string>(nameof(Title), defaultValue: "Homing");

    // Axis Values
    public static readonly StyledProperty<AxisHomingStatus> XAxisHomingStatusProperty = AvaloniaProperty.Register<HomingControl, AxisHomingStatus>(nameof(XAxisHomingStatus), defaultValue: AxisHomingStatus.Unknown);
    public static readonly StyledProperty<AxisHomingStatus> YAxisHomingStatusProperty = AvaloniaProperty.Register<HomingControl, AxisHomingStatus>(nameof(YAxisHomingStatus), defaultValue: AxisHomingStatus.Unknown);
    public static readonly StyledProperty<AxisHomingStatus> ZAxisHomingStatusProperty = AvaloniaProperty.Register<HomingControl, AxisHomingStatus>(nameof(ZAxisHomingStatus), defaultValue: AxisHomingStatus.Unknown);
    public static readonly StyledProperty<AxisHomingStatus> AAxisHomingStatusProperty = AvaloniaProperty.Register<HomingControl, AxisHomingStatus>(nameof(AAxisHomingStatus), defaultValue: AxisHomingStatus.Unknown);
    public static readonly StyledProperty<AxisHomingStatus> BAxisHomingStatusProperty = AvaloniaProperty.Register<HomingControl, AxisHomingStatus>(nameof(BAxisHomingStatus), defaultValue: AxisHomingStatus.Unknown);
    public static readonly StyledProperty<AxisHomingStatus> CAxisHomingStatusProperty = AvaloniaProperty.Register<HomingControl, AxisHomingStatus>(nameof(CAxisHomingStatus), defaultValue: AxisHomingStatus.Unknown);
    public static readonly StyledProperty<AxisHomingStatus> UAxisHomingStatusProperty = AvaloniaProperty.Register<HomingControl, AxisHomingStatus>(nameof(UAxisHomingStatus), defaultValue: AxisHomingStatus.Unknown);
    public static readonly StyledProperty<AxisHomingStatus> VAxisHomingStatusProperty = AvaloniaProperty.Register<HomingControl, AxisHomingStatus>(nameof(VAxisHomingStatus), defaultValue: AxisHomingStatus.Unknown);
    public static readonly StyledProperty<AxisHomingStatus> WAxisHomingStatusProperty = AvaloniaProperty.Register<HomingControl, AxisHomingStatus>(nameof(WAxisHomingStatus), defaultValue: AxisHomingStatus.Unknown);

    // Axis Visibility
    public static readonly StyledProperty<bool> XVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(XVisible), defaultValue: true);
    public static readonly StyledProperty<bool> YVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(YVisible), defaultValue: true);
    public static readonly StyledProperty<bool> ZVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(ZVisible), defaultValue: true);
    public static readonly StyledProperty<bool> AVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(AVisible), defaultValue: true);
    public static readonly StyledProperty<bool> BVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(BVisible), defaultValue: true);
    public static readonly StyledProperty<bool> CVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(CVisible), defaultValue: true);
    public static readonly StyledProperty<bool> UVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(UVisible), defaultValue: true);
    public static readonly StyledProperty<bool> VVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(VVisible), defaultValue: true);
    public static readonly StyledProperty<bool> WVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(WVisible), defaultValue: true);

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public AxisHomingStatus XAxisHomingStatus
    {
        get => GetValue(XAxisHomingStatusProperty);
        set => SetValue(XAxisHomingStatusProperty, value);
    }

    public AxisHomingStatus YAxisHomingStatus
    {
        get => GetValue(YAxisHomingStatusProperty);
        set => SetValue(YAxisHomingStatusProperty, value);
    }

    public AxisHomingStatus ZAxisHomingStatus
    {
        get => GetValue(ZAxisHomingStatusProperty);
        set => SetValue(ZAxisHomingStatusProperty, value);
    }

    public AxisHomingStatus AAxisHomingStatus
    {
        get => GetValue(AAxisHomingStatusProperty);
        set => SetValue(AAxisHomingStatusProperty, value);
    }

    public AxisHomingStatus BAxisHomingStatus
    {
        get => GetValue(BAxisHomingStatusProperty);
        set => SetValue(BAxisHomingStatusProperty, value);
    }

    public AxisHomingStatus CAxisHomingStatus
    {
        get => GetValue(CAxisHomingStatusProperty);
        set => SetValue(CAxisHomingStatusProperty, value);
    }

    public AxisHomingStatus UAxisHomingStatus
    {
        get => GetValue(UAxisHomingStatusProperty);
        set => SetValue(UAxisHomingStatusProperty, value);
    }

    public AxisHomingStatus VAxisHomingStatus
    {
        get => GetValue(VAxisHomingStatusProperty);
        set => SetValue(VAxisHomingStatusProperty, value);
    }

    public AxisHomingStatus WAxisHomingStatus
    {
        get => GetValue(WAxisHomingStatusProperty);
        set => SetValue(WAxisHomingStatusProperty, value);
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

    public IRelayCommand<GenericCommand> HomeAxisCommand { get; }

    public event EventHandler<GenericCommand>? AxisHomingRequested;

    private void HomeAxis(GenericCommand axis)
    {
        AxisHomingRequested?.Invoke(this, axis);
    }

    public HomingControl()
    {
        HomeAxisCommand = new RelayCommand<GenericCommand>(HomeAxis);
        DataContext = this;
        InitializeComponent();
    }
}