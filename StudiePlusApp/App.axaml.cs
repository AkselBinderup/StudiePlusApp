using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using StudiePlusApp.Models.Interfaces;
using StudiePlusApp.Models;
using StudiePlusApp.ViewModels;
using StudiePlusApp.Views;
using System;

namespace StudiePlusApp
{
    public partial class App : Application
    {
        private static IServiceProvider? _serviceProvider;
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var services = new ServiceCollection();

                ConfigureServices(services);
                _serviceProvider = services.BuildServiceProvider();

                // Inject main window with its ViewModel
                var mainWindow = new MainWindow
                {
                    DataContext = GetService<MainWindowViewModel>()
                };

                desktop.MainWindow = mainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<INavigationService>(provider => new NavigationService(provider));

            services.AddSingleton<MainWindowViewModel>();

            services.AddTransient<AbsenceCausePageView>();
            services.AddTransient<AbsenceCausePageViewModel>();

            services.AddTransient<CoursesPageView>();
            services.AddTransient<CoursesPageViewModel>();

            services.AddTransient<FunctionLineView>();
            services.AddTransient<FunctionLineViewModel>();
            
            services.AddTransient<GradesPageView>();
            services.AddTransient<GradesPageViewModel>();

            services.AddTransient<HomePageView>();
            services.AddTransient<HomePageViewModel>();

            services.AddTransient<HomeWorkView>();
            services.AddTransient<HomeWorkViewModel>();

            services.AddTransient<LoginScreenView>();
            services.AddTransient<LoginScreenViewModel>();

            services.AddTransient<MessagePageView>();
            services.AddTransient<MessagesPageViewModel>();

            services.AddTransient<RegisterScreenView>();
            services.AddTransient<RegisterScreenViewModel>();

            services.AddTransient<ScheduleView>();
            services.AddTransient<ScheduleViewModel>();
        }

        public static T GetService<T>() where T : notnull
        {
            if (_serviceProvider == null)
                throw new InvalidOperationException("Service provider is not initialized.");
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}