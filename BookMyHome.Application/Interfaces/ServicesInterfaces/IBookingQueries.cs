using BookMyHome.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Interfaces.ServicesInterfaces
{
	public interface IBookingQueries
	{
		Task<IEnumerable<Booking>?> GetAllBookings();
		Task<Booking?> GetBookingById(int id);
	}
}
