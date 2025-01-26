using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;

namespace GrblExpress.Controls;

public partial class PulldownTextBoxControl : UserControl
{
    public static readonly StyledProperty<string> TextProperty = AvaloniaProperty.Register<PulldownTextBoxControl, string>(nameof(Text), defaultValue: string.Empty);
    public static readonly StyledProperty<List<string>> PreviousEntriesProperty = AvaloniaProperty.Register<PulldownTextBoxControl, List<string>>(nameof(PreviousEntries), defaultValue: []);
    public static readonly StyledProperty<int> MaxPreviousEntriesProperty = AvaloniaProperty.Register<PulldownTextBoxControl, int>(nameof(MaxPreviousEntries), defaultValue: 6);

    public event EventHandler<string>? ReturnPressedRequested;

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public List<string> PreviousEntries
    {
        get => GetValue(PreviousEntriesProperty);
        set => SetValue(PreviousEntriesProperty, value);
    }

    public int MaxPreviousEntries
    {
        get => GetValue(MaxPreviousEntriesProperty);
        set => SetValue(MaxPreviousEntriesProperty, value);
    }

    public void Clear()
    {
        Text = string.Empty;
    }

    public void Save()
    {
        TextBox_KeyUp(null, new Avalonia.Input.KeyEventArgs() { Key = Avalonia.Input.Key.Enter });
    }

    private void ShowFlyout(object sender, RoutedEventArgs e)
    {
        if (PreviousEntries.Count == 0) return;
        if (PreviousEntries.Count > MaxPreviousEntries)
        {
            PreviousEntries.RemoveRange(PreviousEntries.Count - 1, 1);
        }
        FlyoutBase.ShowAttachedFlyout(InputTextBox);
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ListBox lb && lb.SelectedItem is string selected)
        {
            Text = selected;
            FlyoutBase.GetAttachedFlyout(InputTextBox)?.Hide();
        }
    }

    public PulldownTextBoxControl()
    {
        DataContext = this;
        InitializeComponent();
    }

    private void TextBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        if (e.Key == Avalonia.Input.Key.Enter)
        {
            if (string.IsNullOrWhiteSpace(Text)) return;

            if (PreviousEntries.Contains(Text))
            {
                PreviousEntries.Remove(Text);
            }

            PreviousEntries.Insert(0, Text);

            ReturnPressedRequested?.Invoke(this, Text);
        }

        if (e.Key == Avalonia.Input.Key.Down || e.Key == Avalonia.Input.Key.FnDownArrow)
        {
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            ShowFlyout(sender, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}