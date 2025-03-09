using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Services.BookingService.Commands;
using BookMyHome.Domain.CustomException;
using BookMyHome.Domain.Entities;
using Moq;

namespace BookMyHome.UnitTest
{
	public class TestBooking
	{
		[Theory]
		[InlineData(1, 5, 2, 3)] // Overlap in the middle
		[InlineData(1, 3, 2, 4)] // Overlap at the end
		[InlineData(2, 6, 1, 3)] // Overlap at the start
		[InlineData(1, 10, 1, 10)] // Exact match
		[InlineData(3, 5, 1, 6)] // Completely contained within
		public async Task TestBookingThatOverlaps(int checkInDays, int checkOutDays, int existingCheckIn, int existingCheckOut)
		{
			// Arrange 
			var mockBookingRepository = new Mock<IBookingRepository>();
			var bookingService = new BookingCommandsService(mockBookingRepository.Object);

			var newBooking = new Booking(DateTime.Now.AddDays(checkInDays).Date, DateTime.Now.AddDays(checkOutDays).Date); // this goes from day 1 to day 5
			var existingBookings = new List<Booking>
			{
				new Booking(DateTime.Now.AddDays(existingCheckIn).Date, DateTime.Now.AddDays(existingCheckOut).Date) // this goes from day 2 to day 3, so there will be a conflict
			};
			mockBookingRepository.Setup(r => r.GetAllBookings()).ReturnsAsync(existingBookings); // mock setup. my GetAllBookings returns the list above
			await Assert.ThrowsAsync<OverlappingBookingException>(() => bookingService.CreateBooking(newBooking));
		}

		[Theory]
		[InlineData(-10, -5)] // Fully in the past
		[InlineData(-1, 2)]   // Starts in the past, ends in the future
		public void TestBookingInThePast(int checkInDays, int checkOutDays)
		{
			// Act & Assert
			var exception = Assert.Throws<Exception>(() => new Booking(DateTime.Now.AddDays(checkInDays).Date, DateTime.Now.AddDays(checkOutDays).Date));
			Assert.Equal("Cannot book in the past", exception.Message);
		}

		[Theory]
		[InlineData(5, 3)]
		[InlineData(0, 0)]
		public void TestBookingCheckInHasTobeBeforeCheckOut(int checkInDays, int checkOutDays)
		{
			var exception = Assert.Throws<Exception>(() => new Booking(DateTime.Now.AddDays(checkInDays).Date, DateTime.Now.AddDays(checkOutDays).Date));

			Assert.Equal("Check out date has to be on a later date than check in", exception.Message);

		}
	}
}
