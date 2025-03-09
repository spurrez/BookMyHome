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
	public class AccommodationRepository : IAccommodationRepository
	{
		private readonly EntityFrameworkDBContext _dbContext;
		public AccommodationRepository(EntityFrameworkDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<IEnumerable<Accommodation>?> GetAllAccommodations()
		{
			return await _dbContext.Accommodations.AsNoTracking().ToListAsync();
		}

		public async Task<Accommodation?> GetAccommodationById(int id)
		{
			var accommodation = await _dbContext.Accommodations.FindAsync(id);
			if (accommodation == null)
			{
				return null;
			}
			return accommodation;
		}

		public async Task<Accommodation> CreateAccommodation(Accommodation acco)
		{
			var createdBooking = await _dbContext.Accommodations.AddAsync(acco);
			await _dbContext.SaveChangesAsync();
			return createdBooking.Entity;
		}
		public async Task<Accommodation> UpdateAccommodation(int id, Accommodation booking)
		{
			var existingAccomodation = await _dbContext.Accommodations.FindAsync(id);
			if (existingAccomodation == null)
				return null;


			// This sets the original value of the RowVersion to the value provided by the client.
			// When SaveChanges is called, EF Core compares the original RowVersion with the current one in the database.
			// If the RowVersion has changed (i.e., someone else modified the entity), a concurrency exception will be thrown/caught.
			_dbContext.Entry(existingAccomodation).Property(b => b.RowVersion).OriginalValue = booking.RowVersion;

			// change the updated values here
			_dbContext.Update(existingAccomodation); // TODO prob fix this (check how booking is done)

			try
			{
				await _dbContext.SaveChangesAsync();
				return existingAccomodation;

			}
			catch (DbUpdateConcurrencyException)
			{
				throw new InvalidOperationException("The booking was modified by another user.");
			}
		}
		public async Task<bool> DeleteAccommodation(int id)
		{
			var accommodation = await _dbContext.Accommodations.FindAsync(id);

			if (accommodation == null)
				return false;

			_dbContext.Accommodations.Remove(accommodation);
			await _dbContext.SaveChangesAsync();
			return true;
		}
	}
}
