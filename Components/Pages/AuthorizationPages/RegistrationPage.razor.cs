using Blazored.LocalStorage;
using Blazored.LocalStorage.StorageOptions;
using Microsoft.AspNetCore.Components;
using System.Runtime.Intrinsics.X86;
using WenawoMessenger.Client.Components.Models;
using WenawoMessenger.Client.HttpClient.Authorization;
using WenawoMessenger.Client.Models.Token;
using WenawoMessenger.Client.Models.User;
using WenawoMessenger.Client.Models.User.Authorization;
using WenawoMessenger.Client.Services.LocalStorage;

namespace WenawoMessenger.Client.Components.Pages.AuthorizationPages
{
	public partial class RegistrationPage
	{
		[Inject] private IAuthorization _authorization { get; set; } = null!;
		[Inject] private JwtTokens? _tokens { get; set; }
		[Inject] private UserFullData? _userFullData { get; set; }
		[Inject] private NavigationManager _navigation { get; set; } = null!;
		[Inject] private ILocalStorageService _localStorage {  get; set; } = null!;
		[Inject] private IUserStorageService _userStorageService { get; set; } = null!;


		private List<TextFieldStatus> textFieldStatus = new()
		{
			new() { Label = "Электронная почта" },
			new() { Label = "Логин"},
			new() { Label = "Пароль"},
			new() { Label = "Дата рождения" }
		};

		private string email = string.Empty;
		private string login = string.Empty;
		private string password = string.Empty;
		private DateTime? dateTime = null;
		
		private string errorMessege = string.Empty;

		private async Task Registration(string email, string login, string password, DateTime? dateTime)
		{
			try
			{
				if (email == string.Empty)
				{
					textFieldStatus[0].Errored = true;
					errorMessege = "Заполните все поля";
				};
				if (login == string.Empty)
				{
					textFieldStatus[1].Errored = true;
					errorMessege = "Заполните все поля";
				};
				if (password == string.Empty)
				{
					textFieldStatus[2].Errored = true;
					errorMessege = "Заполните все поля";
				};
				if (dateTime == null)
				{
					textFieldStatus[3].Errored = true;
					errorMessege = "Заполните все поля!";
				};
				if (errorMessege != string.Empty) throw new Exception();

				UserRegModel userRegModel = new(email!, login!, password!, dateTime);

				UserLogResponce responce = await _authorization.RegistrationAsync(userRegModel);

				if (responce != null)
				{
					_tokens!.Refresh(new JwtTokens(responce));
					_userFullData = new(responce);

					await _localStorage.SetItemAsync<UserFullData>("userFullData", _userFullData);
					await _userStorageService.SaveTokenAsync(_tokens);

					_navigation.NavigateTo("chats", replace:  true);
				}
				else
				{
					errorMessege = "Ошибка сервера";
					StateHasChanged();
				}
			}
			catch
			{
				errorMessege = "Необработанная ошибка";
				StateHasChanged();
			}
		}

		private void ErrorCancel(TextFieldStatus textFieldStatus, List<TextFieldStatus> textFieldStatuses)
		{
			textFieldStatus.Errored = false;
			foreach (var status in textFieldStatuses)
			{
				bool statusCheck = false;
				if (status.Errored == true)
				{
					statusCheck = true;
					break;
				}
				if (statusCheck) errorMessege = string.Empty;
			}
		}
		
		private void GoToLogin()
		{
			_navigation.NavigateTo("login", replace: true);
		}
	}

}