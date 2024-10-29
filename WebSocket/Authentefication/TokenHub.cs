using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
using WenawoMessenger.Client.HttpClient;
using WenawoMessenger.Client.Models.Token;
using WenawoMessenger.Client.Services.JwtService;
using WenawoMessenger.Client.Services.LocalStorage;

namespace WenawoMessenger.Client.WebSocket.Authentefication
{
	public class TokenHub(JwtTokens jwtTokens, HttpConfig httpConfig, IUserStorageService userStorageService)
	{
		private string link = httpConfig.AuthenteficationHub;
		private HubConnection? _hubConnection = null;

		public async Task InitializeConnection()
		{
			_hubConnection = new HubConnectionBuilder()
				.WithUrl(link, options =>
				{
					options.AccessTokenProvider = () => jwtTokens.ReturnAccessToken()!;
				}).Build();

			await _hubConnection.StartAsync();
			ConnectionTokens();

			await RefreshingTokenAsync();
		}

		private void ConnectionTokens()
		{
			_hubConnection!.On<JwtTokens>("Tokens", async (tokens) =>
			{
				try
				{
					jwtTokens.Refresh(tokens);
					await userStorageService.SaveTokenAsync(tokens);
					await RefreshingTokenAsync();
				}
				catch { throw new Exception(); }
			});
		}

		private async Task RefreshingTokenAsync()
		{
			if (_hubConnection == null) throw new InvalidOperationException();
			try
			{
				var claimService = new GetClaim();
				var expClaim = claimService.GetJWTTokenClaim(jwtTokens.AccessToken, "exp");
				var expLongParse = long.TryParse(expClaim, out long expLong);

				if (expLongParse)
				{
					var now = DateTime.UtcNow;
					var expDateTime = DateTimeOffset.FromUnixTimeSeconds(expLong).DateTime;
					var a = expDateTime - now;
					var expCounting = (int)(a.TotalSeconds) - 20;

					await Task.Delay(expCounting * 1000);

					await _hubConnection.InvokeAsync("RefreshTokens", jwtTokens);
				}
			}
			catch { throw new Exception(); }
		}
	}
}
