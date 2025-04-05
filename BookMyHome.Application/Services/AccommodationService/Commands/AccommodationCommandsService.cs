using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Interfaces.UnitOfWork;
using BookMyHome.Application.Services.AccommodationService.Interfaces;
using BookMyHome.Domain.CustomException;
using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.AccommodationService.Commands
{
    public class AccommodationCommandsService : IAccommodationCommands
    {

        private readonly IUnitOfWork _unitOfWork;
        public AccommodationCommandsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Accommodation> CreateAccommodation(Accommodation accommodation)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                Accommodation newAccommodation = await _unitOfWork.AccommodationRepository.CreateAccommodation(accommodation);
                await _unitOfWork.CommitTransactionAsync();
                return newAccommodation;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<Accommodation> UpdateAccommodation(int id, Accommodation accommodation)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                Accommodation updatedAccommodation = await _unitOfWork.AccommodationRepository.UpdateAccommodation(id, accommodation);
                await _unitOfWork.CommitTransactionAsync();
                return updatedAccommodation;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<bool> DeleteAccommodation(int id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                bool isDeleted = await _unitOfWork.AccommodationRepository.DeleteAccommodation(id);
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
