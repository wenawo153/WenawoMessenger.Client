using WenawoMessenger.Client.Models.Token;

namespace WenawoMessenger.Client.HttpClient.Token
{
	public interface IToken
	{
		Task<JwtTokens> RefreshTokenAsync(JwtTokens tokens);
	}
}