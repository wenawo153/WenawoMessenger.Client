using Microsoft.AspNetCore.Components;
using MudBlazor;
using WenawoMessenger.Client.Components.Layout.Dialogs;
using WenawoMessenger.Client.Models.Chat;
using WenawoMessenger.Client.Models.Token;
using WenawoMessenger.Client.Services.LocalStorage;
using WenawoMessenger.Client.WebSocket.Authentefication;

namespace WenawoMessenger.Client.Components.Pages.ChatPages
{
	public partial class ChatsPage
	{
		[Inject] private NavigationManager _navigation { get; set; } = null!;
		[Inject] private JwtTokens _tokens { get; set; } = null!;
		[Inject] private IUserStorageService _userStorageService { get; set; } = null!;
		[Inject] private TokenHub _tokenHub { get; set; } = null!;
		[Inject] private List<ChatFullData> _chats { get; set; } = null!;

		public bool _open = false;

		protected override async Task OnInitializedAsync()  
		{
			await _tokenHub.InitializeConnection();
		}

		public void ToggleDrawer()
		{
			_open = !_open;
		}

		public void OnSwipeEnd(SwipeEventArgs e)
		{
			if (e.SwipeDirection == MudBlazor.SwipeDirection.LeftToRight && !_open)
			{
				_open = true;
				StateHasChanged();
			}
			else if (e.SwipeDirection == MudBlazor.SwipeDirection.RightToLeft && _open)
			{
				_open = false;
				StateHasChanged();
			}
		}

		private Task OpenExitDialogAsync()
		{
			var options = new DialogOptions { CloseOnEscapeKey = true };

			return DialogService.ShowAsync<ExitAccountDialog>("Выход из аккаунта", options);
		}

		public List<ListItemContent> listItems = new(){
		new()
		{
			ChatAvatarLink = "/static/images/user-image.png",
			ChatName = "1111111",
			LastMessege = "Hello"
		},
		new()
		{
			ChatAvatarLink = "/static/images/user-image.png",
			ChatName = "1111111",
			LastMessege = "Hello"
		},
		new()
		{
			ChatAvatarLink = "/static/images/user-image.png",
			ChatName = "1111111",
			LastMessege = "Hello"
		},
		new()
		{
			ChatAvatarLink = "/static/images/user-image.png",
			ChatName = "1111111",
			LastMessege = "Hello"
		},
		new()
		{
			ChatAvatarLink = "/static/images/user-image.png",
			ChatName = "1111111",
			LastMessege = "Hello"
		},
		new()
		{
			ChatAvatarLink = "/static/images/user-image.png",
			ChatName = "1111111",
			LastMessege = "Hello"
		}
	};
		public class ListItemContent
		{
			public string ChatName { get; set; } = null!;
			public string ChatAvatarLink { get; set; } = null!;
			public string LastMessege { get; set; } = null!;
		}
	}
}
