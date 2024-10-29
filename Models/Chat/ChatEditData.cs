namespace WenawoMessenger.Client.Models.Chat
{
	public class ChatEditData
	{
		public int Id { get; set; }
		public string ChatName { get; set; } = null!;
		public string HostId { get; set; } = null!;
		public List<string> UsersId { get; set; } = null!;
	}
}
