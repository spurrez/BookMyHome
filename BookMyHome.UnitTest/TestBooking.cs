using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Interfaces.ServicesInterfaces;
using BookMyHome.Application.Services;
using BookMyHome.Core.CustomException;
using BookMyHome.Core.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.UnitTest
{
	public class TestBooking
	{
		//private readonly Mock<IBookingRepository> mockBookingRepository;
		//private readonly BookingService _bookingService;

		public TestBooking()
		{
			// Arrange 
			var mockBookingRepository = new Mock<IBookingRepository>();
			var bookingService = new BookingService(mockBookingRepository.Object);

		}
		[Fact]
		public async Task TestBookingThatOverlaps()
		{
			// Arrange 
			var mockBookingRepository = new Mock<IBookingRepository>();
			var bookingService = new BookingService(mockBookingRepository.Object);

			var newBooking = new Booking(DateTime.Now.AddDays(1).Date, DateTime.Now.AddDays(5).Date); // this goes from day 1 to day 5
			var existingBookings = new List<Booking>
			{
				new Booking(DateTime.Now.AddDays(2).Date, DateTime.Now.AddDays(3).Date) // this goes from day 2 to day 3, so there will be a conflict
			};
			mockBookingRepository.Setup(r => r.GetAllBookings()).ReturnsAsync(existingBookings); // mock setup. my GetAllBookings returns the list above
			// Act and Assert
			await Assert.ThrowsAsync<OverlappingBookingException>(() => bookingService.CreateBooking(newBooking));
		}

		[Fact]
		public async Task TestBookingInThePast()
		{
			// Act & Assert
			var exception = Assert.Throws<Exception>(() => new Booking(DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5)));

			Assert.Equal("Cannot book in the past", exception.Message);
		}

		[Fact]
		public async Task TestBookingCheckInHasTobeBeforeCheckOut()
		{
			var exception = Assert.Throws<Exception>(() => new Booking(DateTime.Now.AddDays(5), DateTime.Now.AddDays(3)));

			Assert.Equal("Check out date has to be on a later date than check in", exception.Message);

		}
	}
}
