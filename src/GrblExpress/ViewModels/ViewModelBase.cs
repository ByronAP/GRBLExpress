using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace GrblExpress.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private readonly ILogger? _logger;

        public ViewModelBase(ILogger? logger) => _logger = logger;
    }
}
