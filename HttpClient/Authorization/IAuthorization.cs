using WenawoMessenger.Client.Models.User.Authorization;

namespace WenawoMessenger.Client.HttpClient.Authorization
{
	public interface IAuthorization
	{
		Task<UserLogResponce> LoginAsync(UserLogModel logModel);
		Task<UserLogResponce> RegistrationAsync(UserRegModel regModel);
	}
}