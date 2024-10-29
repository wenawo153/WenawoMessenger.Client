using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System.Reflection;
using WenawoMessenger.Client.HttpClient;
using WenawoMessenger.Client.HttpClient.Authorization;
using WenawoMessenger.Client.HttpClient.Token;
using WenawoMessenger.Client.Models.Chat;
using WenawoMessenger.Client.Models.Token;
using WenawoMessenger.Client.Models.User;
using WenawoMessenger.Client.Services.LocalStorage;
using WenawoMessenger.Client.WebSocket.Authentefication;

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
			builder.Services.AddBlazoredLocalStorage();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif


			#region Configurations

			builder.Configuration.AddConfiguration(new ConfigurationBuilder()
				.AddJsonStream(Assembly.GetExecutingAssembly()
				.GetManifestResourceStream("WenawoMessenger.Client.appsettings.json")!)
				.Build());

			#endregion

			#region HttpClient

			var httpConfig = builder.Configuration.GetSection("HttpUrl").Get<HttpConfig>()
				?? throw new Exception("No url's");

			builder.Services.AddSingleton<IAuthorization, Authorization>();
			builder.Services.AddSingleton<IToken, Token>();

			#endregion

			#region Singleton

			builder.Services.AddSingleton(_ => new HttpConfig(httpConfig));
			builder.Services.AddSingleton<JwtTokens>();
			builder.Services.AddSingleton<UserFullData>();
			builder.Services.AddSingleton<List<ChatFullData>>();

			#endregion

			#region LocalStorage

			builder.Services.AddSingleton<IUserStorageService, UserStorageService>();

			#endregion

			#region WebSocket

			builder.Services.AddSingleton<TokenHub>();

			#endregion


			return builder.Build();
		}
	}
}
