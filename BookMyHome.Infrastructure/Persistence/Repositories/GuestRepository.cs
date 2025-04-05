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
	public class GuestRepository : IGuestRepository
	{
		private readonly EntityFrameworkDBContext _dbContext;
		public GuestRepository(EntityFrameworkDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<IEnumerable<GuestUser>?> GetAllGuests()
		{
			return await _dbContext.Guests.AsNoTracking().ToListAsync();
		}

		public async Task<GuestUser?> GetGuestById(int id)
		{
			var guest = await _dbContext.Guests.FindAsync(id);
			if (guest == null)
			{
				return null;
			}
			return guest;
		}

		public async Task<GuestUser> CreateGuest(GuestUser guest)
		{
			var createdGuest = await _dbContext.Guests.AddAsync(guest);
			await _dbContext.SaveChangesAsync();
			return createdGuest.Entity;
		}
		public async Task<GuestUser> UpdateGuest(int id, GuestUser guest)
		{
			var existingGuest = await _dbContext.Guests.FindAsync(id);
			if (existingGuest == null)
				return null;


			// This sets the original value of the RowVersion to the value provided by the client.
			// When SaveChanges is called, EF Core compares the original RowVersion with the current one in the database.
			// If the RowVersion has changed (i.e., someone else modified the entity), a concurrency exception will be thrown/caught.
			_dbContext.Entry(existingGuest).Property(b => b.RowVersion).OriginalValue = guest.RowVersion;
			_dbContext.Entry(existingGuest).CurrentValues.SetValues(guest);

			try
			{
				await _dbContext.SaveChangesAsync();
				return existingGuest;

			}
			catch (DbUpdateConcurrencyException)
			{
				throw new InvalidOperationException("The booking was modified by another user.");
			}
		}
		public async Task<bool> DeleteGuest(int id)
		{
			var guest = await _dbContext.Guests.FindAsync(id);

			if (guest == null)
				return false;

			_dbContext.Guests.Remove(guest);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<GuestUser?> GetGuestByName(string firstName, string lastName)
		{
			var guest = await _dbContext.Guests.FirstOrDefaultAsync(g => g.FirstName == firstName && g.LastName == lastName);
			if (guest == null)
				return null;
			return guest;
		}

		// the below might have to do in booking instead of guest repo
        //public async Task<IEnumerable<Guest>> GetGuestsWithActiveBookings()
        //{
        //    return await _dbContext.Guests
        //        .Include(g => g.)
        //        .Where(g => g.Bookings.Any(b => b.CheckIn > DateTime.UtcNow))
        //        .ToListAsync();
        //}
    }
}
