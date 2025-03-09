using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.HostService.Interfaces
{
    public interface IHostQueries
    {
        Task<IEnumerable<Host>?> GetAllHosts();
        Task<Host?> GetHostById(int id);
    }
}
