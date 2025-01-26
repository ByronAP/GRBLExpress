using CommunityToolkit.Mvvm.Input;
using GrblExpress.Common.Objects;
using GrblExpress.Common.Types;
using Microsoft.Extensions.Logging;
using System;

namespace GrblExpress.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private GrblMachine _grblMachine;
        private string _statusMessage;
        private bool _isSplitViewPaneOpen;

        public MainWindowViewModel(ILogger<MainWindowViewModel> logger) : base(logger)
        {
            _grblMachine = new GrblMachine();
            ConnectCommand = new RelayCommand(Connect);
            DisconnectCommand = new RelayCommand(Disconnect);
            NewCommand = new RelayCommand(New);
            OpenCommand = new RelayCommand(Open);
            SaveCommand = new RelayCommand(Save);
            ExitCommand = new RelayCommand(Exit);
            UndoCommand = new RelayCommand(Undo);
            RedoCommand = new RelayCommand(Redo);
            AboutCommand = new RelayCommand(About);
            NavigateHomeCommand = new RelayCommand(NavigateHome);
            NavigateSettingsCommand = new RelayCommand(NavigateSettings);
            NavigateProfileCommand = new RelayCommand(NavigateProfile);

            // Initialize default values
            _statusMessage = "Ready";
            _isSplitViewPaneOpen = false;
        }

        public MainWindowViewModel() : base(null)
        {
            _grblMachine = new GrblMachine();
            ConnectCommand = new RelayCommand(Connect);
            DisconnectCommand = new RelayCommand(Disconnect);
            NewCommand = new RelayCommand(New);
            OpenCommand = new RelayCommand(Open);
            SaveCommand = new RelayCommand(Save);
            ExitCommand = new RelayCommand(Exit);
            UndoCommand = new RelayCommand(Undo);
            RedoCommand = new RelayCommand(Redo);
            AboutCommand = new RelayCommand(About);
            NavigateHomeCommand = new RelayCommand(NavigateHome);
            NavigateSettingsCommand = new RelayCommand(NavigateSettings);
            NavigateProfileCommand = new RelayCommand(NavigateProfile);

            // Initialize default values
            _statusMessage = "Ready";
            _isSplitViewPaneOpen = false;
        }

        public GrblMachineState MachineState
        {
            get => _grblMachine.State;
            set
            {
                if (_grblMachine.State != value)
                {
                    _grblMachine.State = value;
                    OnPropertyChanged();
                }
            }
        }

        public Coordinates MachinePosition
        {
            get => _grblMachine.MachinePosition;
            set
            {
                if (_grblMachine.MachinePosition != value)
                {
                    _grblMachine.MachinePosition = value;
                    OnPropertyChanged();
                }
            }
        }

        public Coordinates WorkPosition
        {
            get => _grblMachine.WorkPosition;
            set
            {
                if (_grblMachine.WorkPosition != value)
                {
                    _grblMachine.WorkPosition = value;
                    OnPropertyChanged();
                }
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                if (_statusMessage != value)
                {
                    _statusMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsSplitViewPaneOpen
        {
            get => _isSplitViewPaneOpen;
            set
            {
                if (_isSplitViewPaneOpen != value)
                {
                    _isSplitViewPaneOpen = value;
                    OnPropertyChanged();
                }
            }
        }

        public IRelayCommand ConnectCommand { get; }
        public IRelayCommand DisconnectCommand { get; }
        public IRelayCommand NewCommand { get; }
        public IRelayCommand OpenCommand { get; }
        public IRelayCommand SaveCommand { get; }
        public IRelayCommand ExitCommand { get; }
        public IRelayCommand UndoCommand { get; }
        public IRelayCommand RedoCommand { get; }
        public IRelayCommand AboutCommand { get; }
        public IRelayCommand NavigateHomeCommand { get; }
        public IRelayCommand NavigateSettingsCommand { get; }
        public IRelayCommand NavigateProfileCommand { get; }

        private void Connect()
        {
            // Logic to connect to the machine
        }

        private void Disconnect()
        {
            // Logic to disconnect from the machine
        }

        private void New()
        {
            // Logic to create a new file or project
            Console.WriteLine("New command executed.");
        }

        private void Open()
        {
            // Logic to open an existing file or project
            Console.WriteLine("Open command executed.");
        }

        private void Save()
        {
            // Logic to save the current file or project
            Console.WriteLine("Save command executed.");
        }

        private void Exit()
        {
            // Logic to exit the application
            Console.WriteLine("Exit command executed.");
            Environment.Exit(0);
        }

        private void Undo()
        {
            // Logic to undo the last action
            Console.WriteLine("Undo command executed.");
        }

        private void Redo()
        {
            // Logic to redo the last undone action
            Console.WriteLine("Redo command executed.");
        }

        private void About()
        {
            // Logic to show the about dialog
            Console.WriteLine("About command executed.");
        }

        public void ChangeSplitViewPaneStatusCommand()
        {
            this.IsSplitViewPaneOpen = !this.IsSplitViewPaneOpen;
        }

        private void NavigateHome()
        {
            //CurrentView = new MainWindowViewModel();
            StatusMessage = "Navigated to Home";
        }

        private void NavigateSettings()
        {
            //CurrentView = new MainWindowViewModel();
            StatusMessage = "Navigated to Settings";
        }

        private void NavigateProfile()
        {
            //CurrentView = new MainWindowViewModel();
            StatusMessage = "Navigated to Profile";
        }
    }
}
