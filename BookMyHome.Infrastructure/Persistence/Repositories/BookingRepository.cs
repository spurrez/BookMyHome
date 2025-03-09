using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Core.Entities;
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
		public async Task<IEnumerable<Booking>?> GetAllBookings()
		{
			return await _dbContext.Bookings.AsNoTracking().ToListAsync();
		}

		public async Task<Booking?> GetBookingById(int id)
		{
			var booking = await _dbContext.Bookings.FindAsync(id);
			if (booking == null)
			{
				return null;
			}
			return booking;
		}

		public async Task<Booking> CreateBooking(Booking booking)
		{
			var createdBooking = await _dbContext.Bookings.AddAsync(booking);
			await _dbContext.SaveChangesAsync();
			return createdBooking.Entity;
		}
		public async Task<Booking> UpdateBooking(int id, Booking booking)
		{
			var existingBooking = await _dbContext.Bookings.FindAsync(id);
			if (existingBooking == null)
				return null;


			// This sets the original value of the RowVersion to the value provided by the client.
			// When SaveChanges is called, EF Core compares the original RowVersion with the current one in the database.
			// If the RowVersion has changed (i.e., someone else modified the entity), a concurrency exception will be thrown/caught.
			_dbContext.Entry(existingBooking).Property(b => b.RowVersion).OriginalValue = booking.RowVersion;

			// change the updated values here
			existingBooking.CheckIn = booking.CheckIn;
			existingBooking.CheckOut = booking.CheckOut;

			// not sure if this is optimal
			// could just do this:
			//dbContext.Entry(existingBooking).CurrentValues.SetValues(booking); 

			try
			{
				await _dbContext.SaveChangesAsync();
				return existingBooking;

			}
			catch (DbUpdateConcurrencyException)
			{
				throw new InvalidOperationException("The booking was modified by another user.");
			}
		}
		public async Task<bool> DeleteBooking(int id)
		{
			var booking = await _dbContext.Bookings.FindAsync(id);

			if (booking == null)
				return false;

			_dbContext.Bookings.Remove(booking);
			await _dbContext.SaveChangesAsync();
			return true;
		}
	}
}
