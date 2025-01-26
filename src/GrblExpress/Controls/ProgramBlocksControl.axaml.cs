using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using GrblExpress.Common.Objects;
using System;

namespace GrblExpress.Controls;

public partial class ProgramBlocksControl : UserControl
{
    public static readonly StyledProperty<ProgramBlocks> ProgramBlocksProperty = AvaloniaProperty.Register<ProgramBlocksControl, ProgramBlocks>(nameof(ProgramBlocks));
    public static readonly StyledProperty<bool> ReadOnlyProperty = AvaloniaProperty.Register<ProgramBlocksControl, bool>(nameof(ReadOnly), false);

    public ProgramBlocks ProgramBlocks
    {
        get => GetValue(ProgramBlocksProperty);
        set
        {
            SetValue(ProgramBlocksProperty, value);
        }
    }

    public bool ReadOnly
    {
        get => GetValue(ReadOnlyProperty);
        set
        {
            SetValue(ReadOnlyProperty, value);
        }
    }

    public IRelayCommand<string> ContextMenuCommand { get; }

    private void ContextMenuCommandHandler(string? command)
    {
        var selectedBlockIndex = ProgramBlocksDataGrid.SelectedIndex;

        if (string.IsNullOrEmpty(command) || selectedBlockIndex == -1) return;

        switch (command)
        {
            case "IA":
                // Insert above the selected line
                InsertBlock(selectedBlockIndex);
                ProgramBlocksDataGrid.SelectedIndex = selectedBlockIndex - 1;
                ProgramBlocksDataGrid.SelectedIndex = selectedBlockIndex + 1;
                break;

            case "IB":
                // Insert below the selected line
                InsertBlock(selectedBlockIndex + 1);
                ProgramBlocksDataGrid.SelectedIndex = selectedBlockIndex + 1;
                ProgramBlocksDataGrid.SelectedIndex = selectedBlockIndex - 1;
                break;

            case "D":
                ProgramBlocks.Blocks.RemoveAt(selectedBlockIndex);
                ReindexLineNumbers();
                ProgramBlocksDataGrid.SelectedIndex = selectedBlockIndex - 1;
                break;

            case "C":
                ProgramBlocks.Blocks[selectedBlockIndex].Data = "";
                break;
        }
    }

    private void InsertBlock(int insertIndex)
    {
        // clamp insertIndex so we don't go out of bounds
        insertIndex = Math.Clamp(insertIndex, 0, ProgramBlocks.Blocks.Count);

        var newBlock = new ProgramBlock { Index = insertIndex + 1, Data = string.Empty };
        ProgramBlocks.Blocks.Insert(insertIndex, newBlock);

        ReindexLineNumbers();
    }

    private void ReindexLineNumbers()
    {
        for (int i = 0; i < ProgramBlocks.Blocks.Count; i++)
        {
            ProgramBlocks.Blocks[i].Index = i + 1;
        }
    }

    public ProgramBlocksControl()
    {
        ProgramBlocks = ProgramBlocks.LoadDemoData();
        ContextMenuCommand = new RelayCommand<string>(ContextMenuCommandHandler);
        DataContext = this;
        InitializeComponent();
    }
}
