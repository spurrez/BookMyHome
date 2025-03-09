using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.BookingService.Interfaces
{
    public interface IBookingQueries
    {
        Task<IEnumerable<Booking>?> GetAllBookings();
        Task<Booking?> GetBookingById(int id);
    }
}
