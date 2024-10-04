using MudBlazor;

namespace WenawoMessenger.Client.Components.Pages.ChatPages
{
	public partial class ChatsPage
	{
		public bool _open = false;

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
		},
		new()
		{
			ChatAvatarLink = "/static/images/user-image.png",
			ChatName = "1111111",
			LastMessege = "Hello"
		},
	};
		public class ListItemContent
		{
			public string ChatName { get; set; } = null!;
			public string ChatAvatarLink { get; set; } = null!;
			public string LastMessege { get; set; } = null!;
		}
	}
}
