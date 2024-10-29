using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenawoMessenger.Client.Components.Models
{
	public class TextFieldStatus
	{
		public string Label {  get; set; } = string.Empty;
		public bool Errored { get; set; } = false;
	}
}
