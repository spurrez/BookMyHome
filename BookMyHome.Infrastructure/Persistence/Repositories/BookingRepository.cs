using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Core.Entities;
using BookMyHome.Infrastructure.EntityFrameWork;
using BookMyHome.Infrastructure.Persistence.Interfaces;
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
		private readonly EntityFrameworkDBContext dbContext;
        public BookingRepository(EntityFrameworkDBContext context)
        {
            dbContext = context;
        }
        public async Task<IEnumerable<Booking>?> GetAllBookings()
        {
            return await dbContext.Bookings.ToListAsync();
        }

		public async Task<Booking?> GetBookingById(Guid id)
		{
			var booking = await dbContext.Bookings.FindAsync(id);

			if (booking == null)
			{
				return null;
			}
			return booking;
		}

		public async Task<Booking> CreateBooking(Booking booking)
        {
            var createdBooking = await dbContext.Bookings.AddAsync(booking);
            await dbContext.SaveChangesAsync();
            return createdBooking.Entity;
        }        
        public async Task<Booking> UpdateBooking(Guid id, Booking booking)
        {
			var existingBooking = await dbContext.Bookings.FindAsync(id); // fix
            if (existingBooking == null) 
                return null;

            //dbContext.Entry(existingBooking).CurrentValues.SetValues(booking); // not sure if this is optimal
                                                                               // could just do this:
            existingBooking.CheckIn = booking.CheckIn;
            existingBooking.CheckOut = booking.CheckOut;

            existingBooking.BookingId = id; // did this before in application layer (BookingService)

			await dbContext.SaveChangesAsync();

			return existingBooking;
		}
        public async Task<bool> DeleteBooking(Guid id)
        {
            var booking = await dbContext.Bookings.FindAsync(id);

            if(booking == null)
                return false;

            dbContext.Bookings.Remove(booking);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
