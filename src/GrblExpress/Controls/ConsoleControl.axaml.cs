using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace GrblExpress.Controls;

public partial class ConsoleControl : UserControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<ConsoleControl, string>(nameof(Title), defaultValue: "Console");
    public static readonly StyledProperty<string> TextProperty = AvaloniaProperty.Register<ConsoleControl, string>(nameof(Text), defaultValue: string.Empty);
    public static readonly StyledProperty<bool> VerboseProperty = AvaloniaProperty.Register<ConsoleControl, bool>(nameof(Verbose), defaultValue: false); // show $ and ok
    public static readonly StyledProperty<bool> FilterRealtimeResponsesProperty = AvaloniaProperty.Register<ConsoleControl, bool>(nameof(FilterRealtimeResponses), defaultValue: false); // not sure what this does
    public static readonly StyledProperty<bool> ShowAllRealtimeResponsesProperty = AvaloniaProperty.Register<ConsoleControl, bool>(nameof(ShowAllRealtimeResponses), defaultValue: false); // show everything
    public static readonly StyledProperty<bool> AutoScrollProperty = AvaloniaProperty.Register<ConsoleControl, bool>(nameof(AutoScroll), defaultValue: true);
    public static readonly StyledProperty<int> MaxLinesProperty = AvaloniaProperty.Register<ConsoleControl, int>(nameof(MaxLines), defaultValue: 96);
    public static readonly StyledProperty<int> MaxCharsProperty = AvaloniaProperty.Register<ConsoleControl, int>(nameof(MaxChars), defaultValue: 4096);

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Text
    {
        get => GetValue(TextProperty);
        set
        {
            if (value.Count(c => c == '\n') > MaxLines)
            {
                var lines = value.Split('\n');
                value = string.Join('\n', lines.Skip(1));
                Debug.Print("Trimming lines");
            }

            if (value.Length > MaxChars)
            {
                var excess = value.Length - MaxChars;
                var newlineIndex = value.IndexOf('\n', 0, excess);
                if (newlineIndex != -1)
                {
                    value = value[(newlineIndex + 1)..];
                }
                else
                {
                    value = value[^MaxChars..];
                }
                Debug.Print("Trimming characters");
            }

            SetValue(TextProperty, value);

            if (AutoScroll && !_autoScrollSuspended)
            {
                ConsoleTextScrollViewer.ScrollToEnd();
            }
        }
    }

    public bool Verbose
    {
        get => GetValue(VerboseProperty);
        set => SetValue(VerboseProperty, value);
    }

    public bool FilterRealtimeResponses
    {
        get => GetValue(FilterRealtimeResponsesProperty);
        set => SetValue(FilterRealtimeResponsesProperty, value);
    }

    public bool ShowAllRealtimeResponses
    {
        get => GetValue(ShowAllRealtimeResponsesProperty);
        set => SetValue(ShowAllRealtimeResponsesProperty, value);
    }

    public bool AutoScroll
    {
        get => GetValue(AutoScrollProperty);
        set => SetValue(AutoScrollProperty, value);
    }

    public int MaxLines
    {
        get => GetValue(MaxLinesProperty);
        set => SetValue(MaxLinesProperty, value);
    }

    public int MaxChars
    {
        get => GetValue(MaxCharsProperty);
        set => SetValue(MaxCharsProperty, value);
    }

    private bool _autoScrollSuspended;

    private readonly Timer _testTimer;

    private int i = 0;

    public ConsoleControl()
    {
        DataContext = this;
        InitializeComponent();

        _testTimer = new Timer(_ =>
        {
            if (i >= int.MaxValue - 1) i = 0;

            var randomString = new string(Enumerable.Range(0, 50).Select(_ => (char)('a' + new Random().Next(0, 26))).ToArray());

            Dispatcher.UIThread.Post(() =>
            {
                Text += $"Test-{i}-{randomString}\n";
            });

            i++;
        }, null, 2000, 100);
    }

    private void ScrollViewer_ScrollChanged(object? sender, ScrollChangedEventArgs e)
    {
        if (sender is ScrollViewer sv)
        {
            var maxOffset = sv.Extent.Height - sv.Viewport.Height;
            if (maxOffset < 0) maxOffset = 0;

            if (sv.Offset.Y < maxOffset - 2)
                _autoScrollSuspended = true;
            else
                _autoScrollSuspended = false;
        }
    }

    private void Clear_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Text = string.Empty;
    }

    private async void Save_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            // TODO : Get the StorageProvider via DI
            if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
                desktop.MainWindow?.StorageProvider is not { } provider)
                throw new NullReferenceException("Missing StorageProvider instance.");

            var storageFile = await provider.SaveFilePickerAsync(new FilePickerSaveOptions()
            {
                Title = "Save File",
                DefaultExtension = "txt",
                SuggestedFileName = "console.txt",
                SuggestedStartLocation = await provider.TryGetWellKnownFolderAsync(WellKnownFolder.Documents),
            });

            if (storageFile is null) return;

            var stream = new MemoryStream(Encoding.Default.GetBytes(Text));
            await using var writeStream = await storageFile.OpenWriteAsync();
            await stream.CopyToAsync(writeStream);
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);
        }
    }
}