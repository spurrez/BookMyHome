﻿using BookMyHome.Domain.Entities;
using BookMyHome.Infrastructure.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using BookMyHome.Application.Interfaces.ReposInterfaces;
namespace BookMyHome.Infrastructure.Persistence.Repositories
{
	public class HostRepository : IHostRepository
	{
		private readonly EntityFrameworkDBContext _dbContext;

		public HostRepository(EntityFrameworkDBContext context)
		{
			_dbContext = context;
		}

		public async Task<IEnumerable<HostUser>?> GetAllHosts()
		{
			return await _dbContext.Hosts.AsNoTracking().ToListAsync();
		}

		public async Task<HostUser?> GetHostById(int id)
		{
			var host = await _dbContext.Hosts.FindAsync(id);
			if (host == null)
				return null;
			return host;
		}

		public async Task<HostUser> CreateHost(HostUser entity)
		{
			var createdHost = await _dbContext.Hosts.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return createdHost.Entity;
		}

		public async Task<HostUser> UpdateHost(int id, HostUser host)
		{
			var existingHost = await _dbContext.Hosts.FindAsync(id);
			if (existingHost == null)
				return null;

			_dbContext.Entry(existingHost).Property(b => b.RowVersion).OriginalValue = host.RowVersion;
			_dbContext.Hosts.Update(host); // fix probably

			try
			{
				await _dbContext.SaveChangesAsync();
				return host;
			}
			catch (DbUpdateConcurrencyException)
			{
				throw new InvalidOperationException("The host was modified by another user");
			}
		}
		public async Task<bool> DeleteHost(int id)
		{
			var host = await _dbContext.Hosts.FindAsync(id);
			if (host == null)
				return false;

			_dbContext.Hosts.Remove(host);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<HostUser?> GetHostByEmail(string email)
		{
			return await _dbContext.Hosts.FirstOrDefaultAsync(h => h.Email == email);
		}

		public async Task<HostUser?> GetHostByName(string firstName, string lastName)
		{
			var host = await _dbContext.Hosts.FirstOrDefaultAsync(f => f.FirstName == firstName && f.LastName == lastName);
			if (host == null)
				return null;
			return host;
		}
        //public async Task<IEnumerable<Host>> GetTopRatedHosts()
        //{
        //    return await _dbContext.Hosts.Where(h => h.Rating >= 4.5).ToListAsync();
        //}

    }

}
