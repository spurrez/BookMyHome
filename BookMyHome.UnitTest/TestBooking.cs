using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Interfaces.UnitOfWork;
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
            var unitOfWork = new Mock<IUnitOfWork>();

            var newBooking = new Booking(DateTime.Now.AddDays(checkInDays).Date, DateTime.Now.AddDays(checkOutDays).Date);
            var existingBookings = new List<Booking>
            {
                new Booking(DateTime.Now.AddDays(existingCheckIn).Date, DateTime.Now.AddDays(existingCheckOut).Date)
            };

            // This ensures that when unitOfWork.BookingRepository is accessed, it returns our mocked repository.
			unitOfWork.Setup(u => u.BookingRepository).Returns(mockBookingRepository.Object);

            // Setup repository behavior
            mockBookingRepository.Setup(r => r.GetAllBookings()).ReturnsAsync(existingBookings);

            // Mock transaction methods (to prevent them from affecting test execution) // ty gpt
            unitOfWork.Setup(u => u.BeginTransactionAsync()).Returns(Task.CompletedTask);
            unitOfWork.Setup(u => u.CommitTransactionAsync()).Returns(Task.CompletedTask);
            unitOfWork.Setup(u => u.RollbackTransactionAsync()).Returns(Task.CompletedTask);

            var bookingService = new BookingCommandsService(unitOfWork.Object);

            // Act & Assert
            await Assert.ThrowsAsync<OverlappingBookingException>(() => bookingService.CreateBooking(newBooking));

            // Verify rollback was called since an exception was thrown
            unitOfWork.Verify(u => u.RollbackTransactionAsync(), Times.Once);
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
