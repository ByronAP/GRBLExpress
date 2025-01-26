using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using FluentAvalonia.UI.Controls;
using GrblExpress.Common.Types;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GrblExpress.Controls;

public partial class DroControl : UserControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<DroControl, string>(nameof(Title), defaultValue: "DRO");

    // Axis Values
    public static readonly StyledProperty<double> XProperty = AvaloniaProperty.Register<DroControl, double>(nameof(X), defaultValue: 0);
    public static readonly StyledProperty<double> YProperty = AvaloniaProperty.Register<DroControl, double>(nameof(Y), defaultValue: 0);
    public static readonly StyledProperty<double> ZProperty = AvaloniaProperty.Register<DroControl, double>(nameof(Z), defaultValue: 0);
    public static readonly StyledProperty<double> AProperty = AvaloniaProperty.Register<DroControl, double>(nameof(A), defaultValue: 0);
    public static readonly StyledProperty<double> BProperty = AvaloniaProperty.Register<DroControl, double>(nameof(B), defaultValue: 0);
    public static readonly StyledProperty<double> CProperty = AvaloniaProperty.Register<DroControl, double>(nameof(C), defaultValue: 0);
    public static readonly StyledProperty<double> UProperty = AvaloniaProperty.Register<DroControl, double>(nameof(U), defaultValue: 0);
    public static readonly StyledProperty<double> VProperty = AvaloniaProperty.Register<DroControl, double>(nameof(V), defaultValue: 0);
    public static readonly StyledProperty<double> WProperty = AvaloniaProperty.Register<DroControl, double>(nameof(W), defaultValue: 0);

    // Axis Visibility
    public static readonly StyledProperty<bool> XVisibleProperty = AvaloniaProperty.Register<DroControl, bool>(nameof(XVisible), defaultValue: true);
    public static readonly StyledProperty<bool> YVisibleProperty = AvaloniaProperty.Register<DroControl, bool>(nameof(YVisible), defaultValue: true);
    public static readonly StyledProperty<bool> ZVisibleProperty = AvaloniaProperty.Register<DroControl, bool>(nameof(ZVisible), defaultValue: true);
    public static readonly StyledProperty<bool> AVisibleProperty = AvaloniaProperty.Register<DroControl, bool>(nameof(AVisible), defaultValue: true);
    public static readonly StyledProperty<bool> BVisibleProperty = AvaloniaProperty.Register<DroControl, bool>(nameof(BVisible), defaultValue: true);
    public static readonly StyledProperty<bool> CVisibleProperty = AvaloniaProperty.Register<DroControl, bool>(nameof(CVisible), defaultValue: true);
    public static readonly StyledProperty<bool> UVisibleProperty = AvaloniaProperty.Register<DroControl, bool>(nameof(UVisible), defaultValue: true);
    public static readonly StyledProperty<bool> VVisibleProperty = AvaloniaProperty.Register<DroControl, bool>(nameof(VVisible), defaultValue: true);
    public static readonly StyledProperty<bool> WVisibleProperty = AvaloniaProperty.Register<DroControl, bool>(nameof(WVisible), defaultValue: true);

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public double X
    {
        get => GetValue(XProperty);
        set => SetValue(XProperty, value);
    }

    public double Y
    {
        get => GetValue(YProperty);
        set => SetValue(YProperty, value);
    }

    public double Z
    {
        get => GetValue(ZProperty);
        set => SetValue(ZProperty, value);
    }

    public double A
    {
        get => GetValue(AProperty);
        set => SetValue(AProperty, value);
    }

    public double B
    {
        get => GetValue(BProperty);
        set => SetValue(BProperty, value);
    }

    public double C
    {
        get => GetValue(CProperty);
        set => SetValue(CProperty, value);
    }

    public double U
    {
        get => GetValue(UProperty);
        set => SetValue(UProperty, value);
    }

    public double V
    {
        get => GetValue(VProperty);
        set => SetValue(VProperty, value);
    }

    public double W
    {
        get => GetValue(WProperty);
        set => SetValue(WProperty, value);
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

    public event EventHandler<GenericCommand>? ZeroCommandRequested;

    public IRelayCommand<GenericCommand>? ZeroCommand { get; }

    private void ZeroAxis(GenericCommand command)
    {
        ZeroCommandRequested?.Invoke(this, command);
    }

    private readonly Timer _timer;

    public DroControl()
    {
        ZeroCommand = new RelayCommand<GenericCommand>(ZeroAxis);
        DataContext = this;
        InitializeComponent();

        _timer = new Timer(TimerCallbackMethod, null, 3000, 100);
    }

    private void NumberBox_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs e)
    {
        if (sender.Foreground == Brushes.OrangeRed) return; // don't bother if we are already on the changed color

        _ = Task.Run(async () =>
        {
            await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
            {
                sender.Foreground = Brushes.OrangeRed;
            });

            // Wait for a short duration
            await Task.Delay(200);

            await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
            {
                // we get the forecolor from the button because we could already be set to the new color
                sender.Foreground = DroX0Btn.Foreground;
            });
        });
    }

    // this is just for testing purposes
    private void TimerCallbackMethod(object? state)
    {
        var rnd = new Random();
        var axis = rnd.Next(9);
        var value = rnd.Next(9999) + rnd.NextDouble();
        value = Math.Round(value, 4); // limit the value to 4 decimal places

        // Switch to the UI thread
        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
        {
            var dro = this.FindControl<NumberBox>($"Dro{GetDroAxisName(axis)}");
            if (dro != null)
            {
                dro.Value = value;
            }
        });
    }

    private static string GetDroAxisName(int axis)
    {
        switch (axis)
        {
            case 0: return "X";
            case 1: return "Y";
            case 2: return "Z";
            case 3: return "A";
            case 4: return "B";
            case 5: return "C";
            case 6: return "U";
            case 7: return "V";
            case 8: return "W";
            default: return string.Empty;
        }
    }
}
