namespace WenawoMessenger.Client.Models.Chat
{
	public class ChatFullData
	{
		public int Id { get; set; }
		public string ChatName { get; set; } = null!;
		public string HostId { get; set; } = null!;
		public List<string> UsersId { get; set; } = null!;
		public DateTime ChatCreatedDateTime { get; set; }
	}
}
