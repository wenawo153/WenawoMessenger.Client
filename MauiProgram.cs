using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using WenawoMessenger.Client.HttpClient;

namespace WenawoMessenger.Client
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            #region HttpClient

            builder.Services.Configure<HttpConfig>(builder.Configuration.GetSection("HttpUrl"));

            #endregion

            #region WebSoket

            #endregion

            #region Singleton

            #endregion



            return builder.Build();
        }
    }
}
