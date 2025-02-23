using BookMyHome.Core.Entities;
using BookMyHome.Infrastructure.EntityFrameWork;
using BookMyHome.Infrastructure.GenericRepo;
using BookMyHome.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Infrastructure.Persistence.Repositories
{
	public class HostRepository : IHostRepository
	{
		private readonly EntityFrameworkDBContext context;

		public HostRepository(EntityFrameworkDBContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<Host?>> GetAll()
		{
			return await context.Hosts.ToListAsync();
		}

		public async Task<Host?> GetUserById(int id)
		{
			return await context.Hosts.FindAsync(id);
		}

		public async Task<Host> Add(Host entity)
		{
			await context.Hosts.AddAsync(entity);  
			await context.SaveChangesAsync();      
			return entity;
		}

		public async Task<Host> Update(Host entity)
		{
			context.Hosts.Update(entity);          
			await context.SaveChangesAsync();      
			return entity;
		}

		public async Task<bool> Delete(int id)
		{
			var host = await context.Hosts.FindAsync(id);
			if (host == null)
				return false;  

			context.Hosts.Remove(host);     
			await context.SaveChangesAsync(); 
			return true; 
		}
	}

}
