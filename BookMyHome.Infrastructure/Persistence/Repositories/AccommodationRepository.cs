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
		public async Task<Accommodation> UpdateAccommodation(int id, Accommodation accommodation)
		{
			var existingAccommodation = await _dbContext.Accommodations.FindAsync(id);
			if (existingAccommodation == null)
				return null;


			_dbContext.Entry(existingAccommodation).Property(b => b.RowVersion).OriginalValue = accommodation.RowVersion;

			// change the updated values here
			_dbContext.Update(existingAccommodation);
            _dbContext.Entry(existingAccommodation).CurrentValues.SetValues(accommodation);

            try
			{
				await _dbContext.SaveChangesAsync();
				return existingAccommodation;

			}
			catch (DbUpdateConcurrencyException)
			{
				throw new InvalidOperationException("The accommodation was modified by another user.");
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

        //public async Task<IEnumerable<Accommodation>> GetAvailableAccommodations()
        //{
        //    return await _dbContext.Set<Accommodation>()
        //        .Where(a => a.IsAvailable)
        //        .ToListAsync();
        //}
    }
}
