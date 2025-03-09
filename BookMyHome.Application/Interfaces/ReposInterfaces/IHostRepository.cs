using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Interfaces.ReposInterfaces
{
	public interface IHostRepository
	{
		Task<IEnumerable<Host>?> GetAllHosts();
		Task<Host?> GetHostById(int id);
		Task<Host> CreateHost(Host host);
		Task<Host> UpdateHost(int id, Host host);
		Task<bool> DeleteHost(int id);
	}
}
