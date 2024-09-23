using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerClassLibraly.Messege
{
	public class MessegeSendData
	{
		public string SenderId { get; set; } = null!;
		public int ChatId { get; set; }
		public string Content { get; set; } = null!;
	}
}
