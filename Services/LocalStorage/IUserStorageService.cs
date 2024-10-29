using WenawoMessenger.Client.Models.Token;

namespace WenawoMessenger.Client.Services.LocalStorage
{
	public interface IUserStorageService
	{
		JwtTokens ReadToken();
		Task<JwtTokens> ReadTokensAsync();
		void SaveToken(JwtTokens tokens);
		Task SaveTokenAsync(JwtTokens tokens);
		void Delete();
	}
}