using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Interfaces.ServicesInterfaces;
using BookMyHome.Application.Services;
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

			var newBooking = new Booking(DateTime.Now.AddDays(1).Date, DateTime.Now.AddDays(2).Date);
			var existingBookings = new List<Booking>
			{
				new Booking(DateTime.Now.AddDays(2).Date, DateTime.Now.AddDays(1).Date)
			};
			mockBookingRepository.Setup(r => r.GetAllBookings()).ReturnsAsync(existingBookings);
			// Act and Assert
			await Assert.ThrowsAsync<Exception>(() => bookingService.CreateBooking(newBooking));
		}

		[Fact]
		public async Task TestBookingInThePast()
		{
			// Arrange 
			var mockBookingRepository = new Mock<IBookingRepository>();
			var bookingService = new BookingService(mockBookingRepository.Object);

			var newBooking = new Booking(DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5));			


			// Act and Assert
			await Assert.ThrowsAsync<Exception>(() => bookingService.CreateBooking(newBooking));
			//Assert.Equal("Cannot book in the past", exception.Message);
		}
	}
}
