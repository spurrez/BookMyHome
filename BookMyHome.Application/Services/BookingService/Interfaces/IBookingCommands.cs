using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.BookingService.Interfaces
{
    public interface IBookingCommands
    {
        // this probably shouldnt be here because im implementing it in the same project (service class)
        // should be in presentation layer (i guess maybexd)
        Task<Booking> CreateBooking(Booking booking);
        Task<Booking> UpdateBooking(int id, Booking booking);
        Task<bool> DeleteBooking(int id);
    }
}
