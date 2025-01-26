using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using GrblExpress.Common.Types;
using System;

namespace GrblExpress.Controls;

public partial class JoggingControl : UserControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<JoggingControl, string>(nameof(Title), defaultValue: "Jogging");

    public static readonly StyledProperty<double> JogDistanceProperty = AvaloniaProperty.Register<JoggingControl, double>(nameof(JogDistance), defaultValue: 0.1);
    public static readonly StyledProperty<int> JogFeedrateProperty = AvaloniaProperty.Register<JoggingControl, int>(nameof(JogFeedrate), defaultValue: 100);

    public event EventHandler<(GenericCommand Command, double Distance, int Feedrate)>? JogRequested;

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public double JogDistance
    {
        get => GetValue(JogDistanceProperty);
        set => SetValue(JogDistanceProperty, value);
    }

    public int JogFeedrate
    {
        get => GetValue(JogFeedrateProperty);
        set => SetValue(JogFeedrateProperty, value);
    }

    public IRelayCommand<GenericCommand> JogCommand { get; }

    private void Jog(GenericCommand cmd)
    {
        JogRequested?.Invoke(this, (cmd, JogDistance, JogFeedrate));
    }

    public JoggingControl()
    {
        JogCommand = new RelayCommand<GenericCommand>(Jog);
        DataContext = this;
        InitializeComponent();
    }
}