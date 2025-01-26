using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System.Linq;

namespace GrblExpress.Controls;

public partial class FontPickerControl : UserControl
{
    public static readonly StyledProperty<IOrderedEnumerable<FontFamily>> AvailableFontsProperty = AvaloniaProperty.Register<FontPickerControl, IOrderedEnumerable<FontFamily>>(nameof(AvailableFonts));
    public static readonly StyledProperty<FontFamily> SelectedFontProperty = AvaloniaProperty.Register<FontPickerControl, FontFamily>(nameof(SelectedFont), defaultValue: "Arial");

    public IOrderedEnumerable<FontFamily> AvailableFonts
    {
        get => GetValue(AvailableFontsProperty);
        set => SetValue(AvailableFontsProperty, value);
    }

    public FontFamily SelectedFont
    {
        get => GetValue(SelectedFontProperty);
        set => SetValue(SelectedFontProperty, value);
    }

    public FontPickerControl()
    {
        AvailableFonts = FontManager.Current.SystemFonts.OrderBy(f => f.Name);
        DataContext = this;
        InitializeComponent();
    }
}