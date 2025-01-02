using Microsoft.Extensions.Logging;
using MobileContactApp.Pages;
using MobileContactApp.ViewModels;

namespace MobileContactApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<EditContactPage>();
            builder.Services.AddSingleton<EditContactViewModel>();
            builder.Services.AddSingleton<AddContactPage>();
            builder.Services.AddSingleton<AddContactViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
