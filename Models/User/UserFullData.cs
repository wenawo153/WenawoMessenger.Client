﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenawoMessenger.Client.Models.User.Authorization;

namespace WenawoMessenger.Client.Models.User
{
	public class UserFullData
	{
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

		public UserFullData() { }

		public UserFullData(UserLogResponce logResponce)
		{
			Email = logResponce.Email;
			Login = logResponce.Login;	
			Phone = logResponce.Phone;
			DateOfBirth = logResponce.DateOfBirth;
			Description = logResponce.Description;
			DateOfRegistration = logResponce.DateOfRegistration;
			LastOnline = logResponce.LastOnline;
			UserFriends = logResponce.UserFriends;
			UserGroups = logResponce.UserGroups;
			UserChats = logResponce.UserChats;
		}
	}
}
