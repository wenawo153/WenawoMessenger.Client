using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenawoMessenger.Client.Models.User.Authorization;

namespace WenawoMessenger.Client.Models.Token
{
	public class JwtTokens
	{
		public string AccessToken { get; set; } = null!;
		public string RefreshToken { get; set; } = null!;

		public JwtTokens() { }

		public JwtTokens(string accessToken, string refreshToken)
		{
			AccessToken = accessToken;
			RefreshToken = refreshToken;
		}

		public JwtTokens(UserLogResponce logResponce)
		{
			AccessToken = logResponce.JwtToken;
			RefreshToken = logResponce.RefreshToken;
		}

		public void Refresh(JwtTokens jwtTokens)
		{
			AccessToken = jwtTokens.AccessToken;
			RefreshToken = jwtTokens.RefreshToken;
		}

		public Task<string> ReturnAccessToken()
		{
			return Task.FromResult(AccessToken);
		}
	}
}
