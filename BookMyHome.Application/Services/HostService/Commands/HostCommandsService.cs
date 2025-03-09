using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Services.HostService.Interfaces;
using BookMyHome.Domain.CustomException;
using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.HostService.Commands
{
    public class HostCommandsService : IHostCommands
    {

        private readonly IHostRepository _hostRepository;

        public HostCommandsService(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }

        public async Task<Host> CreateHost(Host host)
        {
            return await _hostRepository.CreateHost(host);
        }

        public async Task<Host> UpdateHost(int id, Host host)
        {
            return await _hostRepository.UpdateHost(id, host);
        }

        public async Task<bool> DeleteHost(int id)
        {
            return await _hostRepository.DeleteHost(id);
        }
    }
}
