using Avalonia;
using Avalonia.Controls;
using System;
using System.Collections.Generic;

namespace GrblExpress.Controls;

public partial class MdiControl : UserControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<MdiControl, string>(nameof(Title), defaultValue: "MDI");
    public static readonly StyledProperty<bool> EnabledProperty = AvaloniaProperty.Register<MdiControl, bool>(nameof(Enabled), defaultValue: true);
    public static readonly StyledProperty<List<string>> PreviousCommandsProperty = AvaloniaProperty.Register<PulldownTextBoxControl, List<string>>(nameof(PreviousCommands), defaultValue: ["hi", "hellooo", "bye", "goodbye"]);

    public event EventHandler<string>? MdiCommandRequested;

    public List<string> PreviousCommands
    {
        get => GetValue(PreviousCommandsProperty);
        set => SetValue(PreviousCommandsProperty, value);
    }

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public bool Enabled
    {
        get => GetValue(EnabledProperty);
        set => SetValue(EnabledProperty, value);
    }

    public MdiControl()
    {
        DataContext = this;
        InitializeComponent();
    }

    private void Send_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(CommandTextBox.Text.Trim())) return;

        MdiCommandRequested?.Invoke(this, CommandTextBox.Text);
    }

    private void PulldownTextBoxControl_ReturnPressedRequested(object sender, string e)
    {
        MdiCommandRequested?.Invoke(this, e);
    }
}