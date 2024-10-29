using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using WenawoMessenger.Client.HttpClient.Token;
using WenawoMessenger.Client.Models.Token;
using WenawoMessenger.Client.Services.LocalStorage;

namespace WenawoMessenger.Client
{
	public partial class MainPage : ContentPage
	{
		public MainPage(bool initializeResult)
		{
			InitializeComponent();

			if (initializeResult) blazorWebView.StartPath = "chats";
			else blazorWebView.StartPath = "login";
		}
	}
}
