using BookMyHome.Domain.Entities;

namespace BookMyHome.BlazorWebApp.Client.Interfaces
{
	public interface IBookingServiceBlazor
	{
		Task<IEnumerable<Booking>?> GetAllBookings();
		Task<Booking?> GetBookingById(Guid id);
		Task<Booking> CreateBooking(Booking booking);
		Task<Booking> UpdateBooking(Guid id, Booking booking);
		Task<bool> DeleteBooking(Guid id);
	}
}
