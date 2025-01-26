using Avalonia;
using Avalonia.Controls;
using GrblExpress.Common.Objects;

namespace GrblExpress.Controls;

public partial class SDCardControl : UserControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<SDCardControl, string>(nameof(Title), defaultValue: "SD Card");
    public static readonly StyledProperty<SDCardFiles> SDCardFilesProperty = AvaloniaProperty.Register<SDCardControl, SDCardFiles>(nameof(SDCardFiles), defaultValue: SDCardFiles.LoadDemoData());

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public SDCardFiles SDCardFiles
    {
        get => GetValue(SDCardFilesProperty);
        set => SetValue(SDCardFilesProperty, value);
    }

    public SDCardControl()
    {
        DataContext = this;
        InitializeComponent();
    }
}