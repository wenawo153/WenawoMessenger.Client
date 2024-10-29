namespace WenawoMessenger.Client.Models.User.Authorization
{
	public class UserLogModel
	{
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;

		public UserLogModel() { }

		public UserLogModel(string email, string password)
		{
			Email = email;
			Password = password;
		}
	}
}
