using Flurl;
using Flurl.Http;
using WenawoMessenger.Client.Models.User.Authorization;

namespace WenawoMessenger.Client.HttpClient.Authorization
{
	public class Authorization(HttpConfig httpConfig) : IAuthorization
	{
		private readonly string link = httpConfig.AuthorizationLink;

		public async Task<UserLogResponce> LoginAsync(UserLogModel logModel)
		{
			if (logModel == null) throw new ArgumentNullException(nameof(logModel));

			try
			{
				Dictionary<string, string> queryParams = new()
				{
					{"email", logModel.Email},
					{"password", logModel.Password}
				};

				var url = new Url($"{link}/login").SetQueryParams(queryParams);

				UserLogResponce responce = await url.GetJsonAsync<UserLogResponce>();
				if (responce == null) throw new ArgumentNullException(nameof(responce));
				return responce;
			}
			catch { throw new Exception(); };
		}

		public async Task<UserLogResponce> RegistrationAsync(UserRegModel regModel)
		{
			if (regModel == null) throw new ArgumentNullException(nameof(regModel));

			try
			{
				var url = new Url($"{link}/registration");

				UserLogResponce responce = await url.PostJsonAsync(regModel).ReceiveJson<UserLogResponce>();
				if (responce == null) throw new ArgumentNullException(nameof(responce));
				return responce;
			}
			catch { throw new Exception(); };
		}
	}
}
