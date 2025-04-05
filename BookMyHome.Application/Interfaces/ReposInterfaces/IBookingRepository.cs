using BookMyHome.Domain.Entities;
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
		Task<Booking?> GetBookingById(int id);
		Task<Booking> CreateBooking(Booking booking);
		Task<Booking> UpdateBooking(int id, Booking booking);
		Task<bool> DeleteBooking(int id);

		Task<Booking?> GetBookingByIdNoInclude(int id);


    }
}
