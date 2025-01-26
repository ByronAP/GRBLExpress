using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using CommunityToolkit.Mvvm.Input;
using GrblExpress.Common.Types;
using System;

namespace GrblExpress.Controls;

public partial class CycleActionsControl : UserControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<CycleActionsControl, string>(nameof(Title), defaultValue: "");
    public static readonly StyledProperty<bool> TitleVisibleProperty = AvaloniaProperty.Register<CycleActionsControl, bool>(nameof(TitleVisible), defaultValue: false);
    public static readonly StyledProperty<Orientation> OrientationProperty = AvaloniaProperty.Register<CycleActionsControl, Orientation>(nameof(Orientation), defaultValue: Orientation.Horizontal);

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public bool TitleVisible
    {
        get => GetValue(TitleVisibleProperty);
        set => SetValue(TitleVisibleProperty, value);
    }

    public Orientation Orientation
    {
        get => GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    public IRelayCommand<GenericCommand> CycleCommand { get; }

    public event EventHandler<GenericCommand>? CycleCommandRequested;

    private void CommandHandler(GenericCommand command)
    {
        CycleCommandRequested?.Invoke(this, command);
    }

    public CycleActionsControl()
    {
        CycleCommand = new RelayCommand<GenericCommand>(CommandHandler);
        DataContext = this;
        InitializeComponent();
    }
}