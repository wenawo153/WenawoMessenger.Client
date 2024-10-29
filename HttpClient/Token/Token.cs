using Flurl;
using Flurl.Http;
using WenawoMessenger.Client.Models.Token;
using static MudBlazor.CategoryTypes;

namespace WenawoMessenger.Client.HttpClient.Token
{
	public class Token(HttpConfig httpConfig) : IToken
	{
		private readonly string link = httpConfig.AuthenteficationLink;

		public async Task<JwtTokens> RefreshTokenAsync(JwtTokens tokens)
		{
			if (tokens == null) throw new ArgumentNullException(nameof(tokens));

			try
			{
				var url = new Url($"{link}/refreshtoken");

				var responce = await url.PostJsonAsync(tokens).ReceiveJson<JwtTokens>();
				if (responce == null) throw new ArgumentNullException(nameof(responce));
				return responce;
			}
			catch { throw new Exception(); };
		}
	}
}
