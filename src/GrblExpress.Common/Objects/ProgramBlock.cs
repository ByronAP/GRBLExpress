using CommunityToolkit.Mvvm.ComponentModel;

namespace GrblExpress.Common.Objects
{
    public partial class ProgramBlock : ObservableObject
    {
        private int _index;
        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }

        private string _runResult = string.Empty;
        public string RunResult
        {
            get => _runResult;
            set => SetProperty(ref _runResult, value);
        }

        private string _data = string.Empty;
        public string Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }
    }
}
