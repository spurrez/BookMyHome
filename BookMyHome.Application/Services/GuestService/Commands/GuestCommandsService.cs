using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Interfaces.UnitOfWork;
using BookMyHome.Application.Services.GuestService.Interfaces;
using BookMyHome.Domain.CustomException;
using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.GuestService.Commands
{
    public class GuestCommandsService : IGuestCommands
    {

        private readonly IUnitOfWork _unitOfWork;
        public GuestCommandsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GuestUser> CreateGuest(GuestUser guest)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                GuestUser newGuest = await _unitOfWork.GuestRepository.CreateGuest(guest);
                await _unitOfWork.CommitTransactionAsync();
                return newGuest;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<GuestUser> UpdateGuest(int id, GuestUser guest)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                GuestUser updatedGuest = await _unitOfWork.GuestRepository.UpdateGuest(id, guest);
                await _unitOfWork.CommitTransactionAsync();
                return updatedGuest;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<bool> DeleteGuest(int id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                bool isDeleted = await _unitOfWork.GuestRepository.DeleteGuest(id);
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
