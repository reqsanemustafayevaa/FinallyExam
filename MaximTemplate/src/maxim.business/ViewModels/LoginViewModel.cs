using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxim.business.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		[StringLength(maximumLength:60,MinimumLength =9)]

		public string Username { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[StringLength(maximumLength:20,MinimumLength =8)]
		public string Password { get; set; }
	}
}
