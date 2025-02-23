using BookMyHome.Core.Entities;
using BookMyHome.Infrastructure.GenericRepo;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Infrastructure.Persistence.Interfaces
{
	public interface IHostRepository
	{
		Task<IEnumerable<Host?>> GetAll();
		Task<Host?> GetUserById(int id);
		Task<Host> Add(Host entity);
		Task<Host> Update(Host entity);
		Task<bool> Delete(int id);
	}
}
