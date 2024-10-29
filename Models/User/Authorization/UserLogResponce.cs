namespace WenawoMessenger.Client.Models.User.Authorization
{
	public class UserLogResponce
	{
		public string UserId { get; set; } = null!;
		public string JwtToken { get; set; } = null!;
		public string RefreshToken { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Login { get; set; } = null!;
		public string Phone { get; set; } = "No number";
		public DateTime DateOfBirth { get; set; }
		public string Description { get; set; } = "No descriotion";
		public DateTime DateOfRegistration { get; set; }
		public DateTime LastOnline { get; set; }
		public List<string> UserFriends { get; set; } = [];
		public List<string> UserGroups { get; set; } = [];
		public List<string> UserChats { get; set; } = [];
	}
}
