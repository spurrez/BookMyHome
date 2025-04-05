using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.HostService.Interfaces
{
    public interface IHostCommands
    {
        Task<HostUser> CreateHost(HostUser host);
        Task<HostUser> UpdateHost(int id, HostUser host);
        Task<bool> DeleteHost(int id);
    }
}
