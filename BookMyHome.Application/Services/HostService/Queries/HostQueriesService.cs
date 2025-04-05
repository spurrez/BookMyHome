using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Services.HostService.Interfaces;
using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.HostService.Queries
{
    public class HostQueriesService : IHostQueries
    {
        private readonly IHostRepository _hostRepository;

        public HostQueriesService(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }
        public async Task<IEnumerable<HostUser>?> GetAllHosts()
        {
            return await _hostRepository.GetAllHosts();
        }

        public async Task<HostUser?> GetHostById(int id)
        {
            return await _hostRepository.GetHostById(id);
        }

    }
}
