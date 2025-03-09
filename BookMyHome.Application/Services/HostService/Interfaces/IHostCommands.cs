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
        Task<Host> CreateHost(Host host);
        Task<Host> UpdateHost(int id, Host host);
        Task<bool> DeleteHost(int id);
    }
}
