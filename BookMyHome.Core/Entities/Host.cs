using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Core.Entities
{
	public class Host : User
	{
		[Timestamp]
		public byte[] RowVersion { get; set; }
	}
}
