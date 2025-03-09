using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.Entities
{
	public class Guest : User
	{
		public virtual ICollection<Booking>? Bookings { get; set; }
	}
}
