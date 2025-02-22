using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Core;

namespace BookMyHome.Application
{
	internal interface IBooking
	{
		Task<IEnumerable<Booking>> GetAllBookings();
	}
}
