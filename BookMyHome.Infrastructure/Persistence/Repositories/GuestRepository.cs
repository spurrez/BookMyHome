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
		public async Task<IEnumerable<Guest>?> GetAllGuests()
		{
			return await _dbContext.Guests.AsNoTracking().ToListAsync();
		}

		public async Task<Guest?> GetGuestById(int id)
		{
			var guest = await _dbContext.Guests.FindAsync(id);
			if (guest == null)
			{
				return null;
			}
			return guest;
		}

		public async Task<Guest> CreateGuest(Guest guest)
		{
			var createdGuest = await _dbContext.Guests.AddAsync(guest);
			await _dbContext.SaveChangesAsync();
			return createdGuest.Entity;
		}
		public async Task<Guest> UpdateGuest(int id, Guest guest)
		{
			var existingGuest = await _dbContext.Guests.FindAsync(id);
			if (existingGuest == null)
				return null;


			// This sets the original value of the RowVersion to the value provided by the client.
			// When SaveChanges is called, EF Core compares the original RowVersion with the current one in the database.
			// If the RowVersion has changed (i.e., someone else modified the entity), a concurrency exception will be thrown/caught.
			_dbContext.Entry(existingGuest).Property(b => b.RowVersion).OriginalValue = guest.RowVersion;

			// change the updated values here
			_dbContext.Update(existingGuest);

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
	}
}
