using BookMyHome.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookMyHome.Application.Interfaces.ReposInterfaces
{
    public interface IBookingRepository
    {
		Task<IEnumerable<Booking>?> GetAllBookings();
		Task<Booking?> GetBookingById(Guid id);
		Task<Booking> CreateBooking(Booking booking);
		Task<Booking> UpdateBooking(Guid id, Booking booking);
		Task<bool> DeleteBooking(Guid id);

	}
}
