using System.IdentityModel.Tokens.Jwt;

namespace WenawoMessenger.Client.Services.JwtService
{
	public class GetClaim
	{
		public string GetJWTTokenClaim(string token, string claimName)
		{
			try
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
				var claimValue = securityToken.Claims.FirstOrDefault(c => c.Type == claimName)?.Value;
				return claimValue ?? throw new Exception();
			}
			catch (Exception)
			{
				throw new Exception();
			}
		}
	}
}
