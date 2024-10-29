using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WenawoMessenger.Client.Components.Pages.ChatPages
{
	public partial class ChatPage
	{
		[Inject] private IJSRuntime? _jSRuntime { get; set; }

		public int priviousMessegeId;
		public int firstMessegeId;
		public int myId = 1;
		public List<Messege> messeges = new List<Messege>();

		protected override Task OnInitializedAsync()
		{
			Random rnd = new Random();
			for (int i = 0; i < 6; i++)
			{
				messeges.Add(new Messege()
				{
					Id = i,
					UserId = rnd.Next(1, 3),
					Content = "hello"
				});
			}

			firstMessegeId = messeges.First().Id;
			priviousMessegeId = messeges.First().UserId;
			StateHasChanged();
			return base.OnInitializedAsync();
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				await _jSRuntime!.InvokeVoidAsync("scrollToBottom");
			}
		}

	}

	public class Messege
	{
		public int Id { get; set; }
		public string Content { get; set; } = null!;
		public int UserId { get; set; }
	}
}