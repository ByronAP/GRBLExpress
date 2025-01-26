using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using GrblExpress.ViewModels;
using GrblExpress.Views;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Linq;

namespace GrblExpress
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();

            var collection = new ServiceCollection();
            // TODO: Register services --****************************************************--
            collection.AddLogging(builder =>
            {
                var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7, retainedFileTimeLimit: TimeSpan.FromDays(7))
                .CreateLogger();

                builder.AddSerilog(logger);
            });
            collection.AddSingleton<MainWindowViewModel>();

            // Creates a ServiceProvider containing services from the provided IServiceCollection
            var services = collection.BuildServiceProvider();

            var vm = services.GetRequiredService<MainWindowViewModel>();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = vm
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void DisableAvaloniaDataAnnotationValidation()
        {
            // Get an array of plugins to remove
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            // remove each entry found
            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }
        }
    }
}