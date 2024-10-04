using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WenawoMessenger.Client.Components.Pages.ChatPages
{
	public partial class ChatPage
	{
		[Inject] private IJSRuntime? _jSRuntime { get; set; }

		public async void Scroll()
		{
			await _jSRuntime!.InvokeVoidAsync("scrollToBottom");
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			await _jSRuntime!.InvokeVoidAsync("scrollToBottom");
		}

		static public int myId = 1;

		public List<Messege> messeges = new()
		{
			new()
			{
				UserId = 1,
				Content = "hello1"
			},
			new()
			{
				UserId = 1,
				Content = "hello2"
			},
			new()
			{
				UserId = 2,
				Content = "hello3"
			},
			new()
			{
				UserId = 2,
				Content = "hello4"
			},
			new()
			{
				UserId = 2,
				Content = "hello5"
			},
			new()
			{
				UserId = 1,
				Content = "hello6"
			},
			new()
			{
				UserId = 2,
				Content = "hello7"
			},
			new()
			{
				UserId = 1,
				Content = "hello8"
			},
			new()
			{
				UserId = 1,
				Content = "hello9"
			},
			new()
			{
				UserId = 1,
				Content = "hello10"
			},
			new()
			{
				UserId = 1,
				Content = "hello11"
			},
			new()
			{
				UserId = 2,
				Content = "hello12"
			},
			new()
			{
				UserId = 1,
				Content = "hello1"
			},
			new()
			{
				UserId = 1,
				Content = "hello2"
			},
			new()
			{
				UserId = 2,
				Content = "hello3"
			},
			new()
			{
				UserId = 2,
				Content = "hello4"
			},
			new()
			{
				UserId = 2,
				Content = "hello5"
			},
			new()
			{
				UserId = 1,
				Content = "hello6"
			},
			new()
			{
				UserId = 2,
				Content = "hello7"
			},
			new()
			{
				UserId = 1,
				Content = "hello8"
			},
			new()
			{
				UserId = 1,
				Content = "hello9"
			},
			new()
			{
				UserId = 1,
				Content = "hello10"
			},
			new()
			{
				UserId = 1,
				Content = "hello11"
			},
			new()
			{
				UserId = 2,
				Content = "hello12"
			},
		};

	}

	public class Messege
	{
		public string Content { get; set; } = null!;
		public int UserId { get; set; }
	}
}