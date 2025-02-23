using BookMyHome.Application.Interfaces.ServicesInterfaces;
using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services
{
    public class BookingService : IBookingService
	{
		private readonly IBookingRepository _bookingRepository;

		public BookingService(IBookingRepository bookingRepository)
		{
			_bookingRepository = bookingRepository;
		}
		
		public async Task<IEnumerable<Booking>> GetAllBookings()
		{
			return await _bookingRepository.GetAllBookings();
		}

		public async Task<Booking?> GetBookingById(Guid id)
		{
			return await _bookingRepository.GetBookingById(id);
		}

		public async Task<Booking> CreateBooking(Booking booking)
		{
			var existingBookings = await _bookingRepository.GetAllBookings();
			if (booking.IsOverLapping(existingBookings))
				throw new Exception("The booking overlaps with another.");

			return await _bookingRepository.CreateBooking(booking);
		}

		public async Task<Booking> UpdateBooking(Guid id, Booking booking)
		{
			var existingBookings = await _bookingRepository.GetAllBookings();
			if (booking.IsOverLapping(existingBookings))
				throw new Exception("The booking overlaps with another.");
			return await _bookingRepository.UpdateBooking(id, booking);
		}

		public async Task<bool> DeleteBooking(Guid id)
		{
			return await _bookingRepository.DeleteBooking(id);
		}
	}
}
