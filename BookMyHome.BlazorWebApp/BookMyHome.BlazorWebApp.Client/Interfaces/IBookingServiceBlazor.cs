using BookMyHome.BlazorWebApp.Client.DTO;
using BookMyHome.Domain.Entities;

namespace BookMyHome.BlazorWebApp.Client.Interfaces
{
	public interface IBookingServiceBlazor
	{
		Task<IEnumerable<BookingDTO>?> GetAllBookings();
		Task<BookingDTO?> GetBookingById(int id);
		Task<BookingDTO> CreateBooking(BookingDTO booking);
		Task<BookingDTO> UpdateBooking(int id, BookingDTO booking);
		Task<bool> DeleteBooking(int id);
	}
}
