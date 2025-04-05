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
		Task<IEnumerable<HostUser>?> GetAllHosts();
		Task<HostUser?> GetHostById(int id);
		Task<HostUser> CreateHost(HostUser host);
		Task<HostUser> UpdateHost(int id, HostUser host);
		Task<bool> DeleteHost(int id);
		Task<HostUser?> GetHostByName(string firstName, string lastName);
	}
}
