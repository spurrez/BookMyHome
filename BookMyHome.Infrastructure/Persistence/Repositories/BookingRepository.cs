using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Domain.Entities;
using BookMyHome.Infrastructure.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BookMyHome.Infrastructure.Persistence.Repositories
{
	public class BookingRepository : IBookingRepository
	{
		private readonly EntityFrameworkDBContext _dbContext;
		public BookingRepository(EntityFrameworkDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<IEnumerable<Booking>?> GetAllBookings() // probably add more GetAllBookings that doesn't use include
		{
			return await _dbContext.Bookings
				.Include(b => b.Accommodation).ThenInclude(a => a.Host)
				.Include(b => b.Guest)
				.AsNoTracking().ToListAsync();
		}

		public async Task<Booking?> GetBookingByIdNoInclude(int id)
		{
			var booking = await _dbContext.Bookings.FindAsync(id);
			if (booking == null)
			{
				return null;
			}
			return booking;
		}
		public async Task<Booking?> GetBookingById(int id)
		{
			var booking = await _dbContext.Bookings
				.Include(b => b.Accommodation)
				.Include(b => b.Guest)
				.FirstOrDefaultAsync(b => b.BookingId == id);

			return booking;
		}

		public async Task<Booking> CreateBooking(Booking booking) // follow this example :)
		{
			// maybe an if statement checking if there is any accommodation to fix null exception
			if (booking.Accommodation != null)
			{
				_dbContext.Entry(booking.Accommodation).State = EntityState.Unchanged;
			}
			_dbContext.Entry(booking).State = EntityState.Added;
			await _dbContext.SaveChangesAsync();
			return booking;
		}
		public async Task<Booking> UpdateBooking(int id, Booking booking)
		{
			var existingBooking = await _dbContext.Bookings
				.Where(b => b.BookingId == id).FirstOrDefaultAsync();

			if (existingBooking == null)
				return null; // perchance return a default booking aka empty booking


			// This sets the original value of the RowVersion to the value provided by the client.
			// When SaveChanges is called, EF Core compares the original RowVersion with the current one in the database.
			// If the RowVersion has changed (i.e., someone else modified the entity), a concurrency exception will be thrown/caught.
			_dbContext.Entry(existingBooking).Property(b => b.RowVersion).OriginalValue = booking.RowVersion;
			// should perhaps add accommodation state to unchanged but only if i dont want it to be allowed to change in this method
			_dbContext.Entry(existingBooking).CurrentValues.SetValues(booking);

			// could probably eventually consider using below code instead of above because there is reason to not update everything 
			// then u just do the below and use _dbContext.Entry(existingBooking).State = EntityState.Modified
			//existingBooking.CheckIn = booking.CheckIn;
			//existingBooking.CheckOut = booking.CheckOut;

			try
			{
				await _dbContext.SaveChangesAsync();
				return existingBooking;

			}
			catch (DbUpdateConcurrencyException)
			{
				throw new InvalidOperationException("The booking was modified by another user. Please reload the booking and try again.");
			}
		}
		public async Task<bool> DeleteBooking(int id)
		{
			var booking = await _dbContext.Bookings.FindAsync(id);

			if (booking == null)
				return false;
			_dbContext.Entry(booking).Property(b => b.RowVersion).OriginalValue = booking.RowVersion;

			try
			{
				_dbContext.Bookings.Remove(booking);
				await _dbContext.SaveChangesAsync();
				return true;

			}
			catch (DbUpdateConcurrencyException)
			{

				throw new InvalidOperationException("The booking was modified by another user. This cannot be deleted.");

			}

		}
	}
}
