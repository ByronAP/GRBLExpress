using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;
using GrblExpress.Common.Types;
using System;
using System.Windows.Input;

namespace GrblExpress.Controls;

public partial class SpindleControl : UserControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<SpindleControl, string>(nameof(Title), defaultValue: "Spindle");

    public static readonly StyledProperty<bool> IsDirectionEnabledProperty = AvaloniaProperty.Register<SpindleControl, bool>(nameof(IsDirectionEnabled), defaultValue: true);
    public static readonly StyledProperty<bool> IsSpeedEnabledProperty = AvaloniaProperty.Register<SpindleControl, bool>(nameof(IsSpeedEnabled), defaultValue: true);
    public static readonly StyledProperty<bool> IsSpeedOverrideEnabledProperty = AvaloniaProperty.Register<SpindleControl, bool>(nameof(IsSpeedOverrideEnabled), defaultValue: true);

    public static readonly StyledProperty<int> SpeedProperty = AvaloniaProperty.Register<SpindleControl, int>(nameof(Speed), defaultValue: 0);
    public static readonly StyledProperty<int> MinSpeedProperty = AvaloniaProperty.Register<SpindleControl, int>(nameof(MinSpeed), defaultValue: 0);
    public static readonly StyledProperty<int> MaxSpeedProperty = AvaloniaProperty.Register<SpindleControl, int>(nameof(MaxSpeed), defaultValue: 30000);
    public static readonly StyledProperty<SpindleDirectionType> SpindleDirectionProperty = AvaloniaProperty.Register<SpindleControl, SpindleDirectionType>(nameof(SpindleDirection), defaultValue: SpindleDirectionType.Off);
    public static readonly StyledProperty<int> OverridePercentageProperty = AvaloniaProperty.Register<SpindleControl, int>(nameof(OverridePercentage), defaultValue: 100);

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public bool IsDirectionEnabled
    {
        get => GetValue(IsDirectionEnabledProperty);
        set => SetValue(IsDirectionEnabledProperty, value);
    }

    public bool IsSpeedEnabled
    {
        get => GetValue(IsSpeedEnabledProperty);
        set => SetValue(IsSpeedEnabledProperty, value);
    }

    public bool IsSpeedOverrideEnabled
    {
        get => GetValue(IsSpeedOverrideEnabledProperty);
        set => SetValue(IsSpeedOverrideEnabledProperty, value);
    }

    public int Speed
    {
        get => GetValue(SpeedProperty);
        set
        {
            if (value < MinSpeed) value = MinSpeed;
            if (value > MaxSpeed) value = MaxSpeed;
            SetValue(SpeedProperty, value);
        }
    }

    public int MinSpeed
    {
        get => GetValue(MinSpeedProperty);
        set => SetValue(MinSpeedProperty, value);
    }

    public int MaxSpeed
    {
        get => GetValue(MaxSpeedProperty);
        set => SetValue(MaxSpeedProperty, value);
    }

    public SpindleDirectionType SpindleDirection
    {
        get => GetValue(SpindleDirectionProperty);
        set => SetValue(SpindleDirectionProperty, value);
    }

    public int OverridePercentage
    {
        get => GetValue(OverridePercentageProperty);
        set
        {
            if (value < OverrideNumberBox.Minimum) value = Convert.ToInt32(OverrideNumberBox.Minimum);
            if (value > OverrideNumberBox.Maximum) value = Convert.ToInt32(OverrideNumberBox.Maximum);
            SetValue(OverridePercentageProperty, value);
        }
    }

    public ICommand IncreaseOverrideCommand { get; }
    public ICommand DecreaseOverrideCommand { get; }

#pragma warning disable IDE0052 // Remove unread private members
    private readonly DispatcherTimer _flashTimer;
#pragma warning restore IDE0052 // Remove unread private members
    private bool IsFlashing => OverridePercentage != 100;
    private IBrush? DefaultBrush;
    private IBrush FlashBrush;

    public SpindleControl()
    {
        IncreaseOverrideCommand = new RelayCommand(IncreaseOverride);
        DecreaseOverrideCommand = new RelayCommand(DecreaseOverride);

        DataContext = this;
        InitializeComponent();

        FlashBrush = new SolidColorBrush(Colors.Red);
        _flashTimer = new DispatcherTimer(TimeSpan.FromMilliseconds(500), DispatcherPriority.Default, FlashTimer_Tick);

        Loaded += SpindleControl_Loaded;
    }

    private void SpindleControl_Loaded(object? sender, RoutedEventArgs e)
    {
        // We do this because the OverrideLabel.Foreground is not set until after the control is loaded
        DefaultBrush = OverrideLabel.Foreground!;
    }

    private void IncreaseOverride()
    {
        if (OverridePercentage < OverrideNumberBox.Maximum - OverrideNumberBox.LargeChange)
        {
            OverridePercentage += Convert.ToInt32(OverrideNumberBox.LargeChange);
        }
    }

    private void DecreaseOverride()
    {
        if (OverridePercentage > OverrideNumberBox.Minimum + OverrideNumberBox.LargeChange)
        {
            OverridePercentage -= Convert.ToInt32(OverrideNumberBox.LargeChange);
        }
    }

    private void FlashTimer_Tick(object? sender, EventArgs e)
    {
        if (IsFlashing)
        {
            OverrideNumberBox.Foreground = OverrideNumberBox.Foreground == DefaultBrush ? FlashBrush : DefaultBrush;
        }
        else
        {
            if (OverrideNumberBox.Foreground != DefaultBrush) OverrideNumberBox.Foreground = DefaultBrush;
        }
    }

    private void Zero_Speed_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Speed = 0;
    }

    private void Zero_Override_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        OverridePercentage = 100;
    }
}