using BookMyHome.Domain.Entities;
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

		public async Task<IEnumerable<Host?>> GetAllHosts()
		{
			return await _dbContext.Hosts.AsNoTracking().ToListAsync();
		}

		public async Task<Host?> GetHostById(int id)
		{
			var host = await _dbContext.Hosts.FindAsync(id);
			if (host == null)
				return null;
			return host;
		}

		public async Task<Host> CreateHost(Host entity)
		{
			var createdHost = await _dbContext.Hosts.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return createdHost.Entity;
		}

		public async Task<Host> UpdateHost(int id, Host host)
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

		public async Task<Host?> GetHostByEmail(string email)
		{
			return await _dbContext.Hosts.FirstOrDefaultAsync(h => h.Email == email);
		}
        //public async Task<IEnumerable<Host>> GetTopRatedHosts()
        //{
        //    return await _dbContext.Hosts.Where(h => h.Rating >= 4.5).ToListAsync();
        //}

    }

}
