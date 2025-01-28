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
    public static readonly StyledProperty<bool> IsXVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(IsXVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsYVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(IsYVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsZVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(IsZVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsAVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(IsAVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsBVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(IsBVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsCVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(IsCVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsUVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(IsUVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsVVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(IsVVisible), defaultValue: true);
    public static readonly StyledProperty<bool> IsWVisibleProperty = AvaloniaProperty.Register<HomingControl, bool>(nameof(IsWVisible), defaultValue: true);

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