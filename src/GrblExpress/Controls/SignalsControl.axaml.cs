using Avalonia;
using Avalonia.Controls;

namespace GrblExpress.Controls;

public partial class SignalsControl : UserControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<SignalsControl, string>(nameof(Title), defaultValue: "Signals");

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public SignalsControl()
    {
        DataContext = this;
        InitializeComponent();
    }
}