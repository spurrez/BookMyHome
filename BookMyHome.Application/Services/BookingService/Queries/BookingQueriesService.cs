using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Services.BookingService.Interfaces;
using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.BookingService.Queries
{
    public class BookingQueriesService : IBookingQueries
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingQueriesService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<IEnumerable<Booking>?> GetAllBookings()
        {
            return await _bookingRepository.GetAllBookings();
        }

        public async Task<Booking?> GetBookingById(int id)
        {
            return await _bookingRepository.GetBookingById(id);
        }

    }
}
