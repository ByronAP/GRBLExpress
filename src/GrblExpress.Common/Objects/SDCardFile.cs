using CommunityToolkit.Mvvm.ComponentModel;

namespace GrblExpress.Common.Objects
{
    public class SDCardFile : ObservableObject
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _size = string.Empty;
        public string Size
        {
            get => _size;
            set => SetProperty(ref _size, value);
        }

        private string _date = string.Empty;
        public string Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }
    }
}
