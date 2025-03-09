using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Services.BookingService.Interfaces;
using BookMyHome.Domain.CustomException;
using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.BookingService.Commands
{
    public class BookingCommandsService : IBookingCommands
    {

        private readonly IBookingRepository _bookingRepository;

        public BookingCommandsService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            var existingBookings = await _bookingRepository.GetAllBookings();
            if (booking.IsOverLapping(existingBookings))
                throw new OverlappingBookingException(); // refactor

            return await _bookingRepository.CreateBooking(booking);
        }

        public async Task<Booking> UpdateBooking(int id, Booking booking)
        {
            var existingBookings = await _bookingRepository.GetAllBookings();
            if (booking.IsOverLapping(existingBookings))
                throw new OverlappingBookingException();
            return await _bookingRepository.UpdateBooking(id, booking);
        }

        public async Task<bool> DeleteBooking(int id)
        {
            return await _bookingRepository.DeleteBooking(id);
        }
    }
}
