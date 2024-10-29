using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using WenawoMessenger.Client.Components.Models;
using WenawoMessenger.Client.HttpClient.Authorization;
using WenawoMessenger.Client.Models.Token;
using WenawoMessenger.Client.Models.User;
using WenawoMessenger.Client.Models.User.Authorization;
using WenawoMessenger.Client.Services.LocalStorage;

namespace WenawoMessenger.Client.Components.Pages.AuthorizationPages
{
	public partial class LoginPage
	{
		[Inject] private IAuthorization _authorization { get; set; } = null!;
		[Inject] private JwtTokens? _tokens { get; set; }
		[Inject] private UserFullData? _userFullData { get; set; }
		[Inject] private NavigationManager _navigation { get; set; } = null!;
		[Inject] private ILocalStorageService _localStorage { get; set; } = null!;
		[Inject] private IUserStorageService _userStorageService { get; set; } = null!;

		private List<TextFieldStatus> textFieldStatus = new()
		{
			new() { Label = "Электронная почта" },
			new() { Label = "Пароль"},
		};

		private string email = string.Empty;
		private string password = string.Empty;

		private string errorMessege = string.Empty;

		private async Task Login(string login, string password)
		{
			errorMessege = string.Empty;
			try
			{
				if (email == string.Empty)
				{
					textFieldStatus[0].Errored = true;
					errorMessege = "Заполните все поля";
				};
				if (password == string.Empty)
				{
					textFieldStatus[1].Errored = true;
					errorMessege = "Заполните все поля";
				};
				if (errorMessege != string.Empty) throw new Exception();

				UserLogModel userLogModel = new(email!, password!);

				UserLogResponce responce = await _authorization.LoginAsync(userLogModel);

				if (responce != null)
				{
					_tokens!.Refresh(new JwtTokens(responce));
					_userFullData = new(responce);

					await _localStorage.SetItemAsync("userFullData", _userFullData);
					await _userStorageService.SaveTokenAsync(_tokens);

					_navigation.NavigateTo("chats", replace: true);
				}
				else
				{
					errorMessege = "Ошибка сервера";
					StateHasChanged();
				}
			}
			catch
			{
				if (errorMessege == string.Empty)
					errorMessege = "Необработанная ошибка";
				StateHasChanged();
			}
		}

		private void ErrorCancel(TextFieldStatus textFieldStatus, List<TextFieldStatus> textFieldStatuses)
		{
			textFieldStatus.Errored = false;
			foreach(var status in textFieldStatuses)
			{
				bool statusCheck = false;
				if (status.Errored == true)
				{
					statusCheck = true;
					break;
				}
				if (!statusCheck) errorMessege = string.Empty;
			}
		}


		private void GoToRegisration()
		{
			_navigation.NavigateTo("registration", replace: true);
		}
	}
}