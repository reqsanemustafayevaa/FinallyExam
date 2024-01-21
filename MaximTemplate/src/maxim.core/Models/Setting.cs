using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxim.core.Models
{
	public class Setting:BaseEntity
	{
		[Required]
		[StringLength(70)]
		public string Value { get; set; }
		[StringLength(30)]
		public string? Key { get; set; }
	}
}
