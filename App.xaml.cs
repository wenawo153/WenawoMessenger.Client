using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using WenawoMessenger.Client.HttpClient.Token;
using WenawoMessenger.Client.Models.Token;
using WenawoMessenger.Client.Services.LocalStorage;
using Application = Microsoft.Maui.Controls.Application;

namespace WenawoMessenger.Client
{
    public partial class App : Application
    {
        public App(JwtTokens tokens, IUserStorageService userStorageService, IToken tokenService)
        {

			bool initializeResult = false;

			try
			{
				var oldToken = userStorageService.ReadToken();
				var newToken = Task.Run(async () => await tokenService.RefreshTokenAsync(oldToken)).Result;
				userStorageService.SaveToken(newToken);
				tokens.Refresh(newToken);

				initializeResult = true;
			}
			catch { }

            InitializeComponent();

			MainPage = new MainPage(initializeResult);
		}
	}
}
