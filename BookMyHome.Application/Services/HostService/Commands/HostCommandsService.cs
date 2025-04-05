using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Interfaces.UnitOfWork;
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

        private readonly IUnitOfWork _unitOfWork;

        public HostCommandsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HostUser> CreateHost(HostUser host)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                HostUser newHost = await _unitOfWork.HostRepository.CreateHost(host);
                await _unitOfWork.CommitTransactionAsync();
                return newHost;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<HostUser> UpdateHost(int id, HostUser host)
        {
            await _unitOfWork.CommitTransactionAsync();
            try
            {
                HostUser updatedHost = await _unitOfWork.HostRepository.UpdateHost(id, host);
                await _unitOfWork.CommitTransactionAsync();
                return updatedHost;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<bool> DeleteHost(int id)
        {
            await _unitOfWork.CommitTransactionAsync();
            try
            {
                bool isDeleted = await _unitOfWork.HostRepository.DeleteHost(id);
                await _unitOfWork.CommitTransactionAsync();
                return isDeleted;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
