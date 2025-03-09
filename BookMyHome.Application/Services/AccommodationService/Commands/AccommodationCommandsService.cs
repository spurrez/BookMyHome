using BookMyHome.Application.Interfaces.ReposInterfaces;
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

        private readonly IAccommodationRepository _accommodationRepository;

        public AccommodationCommandsService(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }

        public async Task<Accommodation> CreateAccommodation(Accommodation accommodation)
        {
            return await _accommodationRepository.CreateAccommodation(accommodation);
        }

        public async Task<Accommodation> UpdateAccommodation(int id, Accommodation accommodation)
        {
            return await _accommodationRepository.UpdateAccommodation(id, accommodation);
        }

        public async Task<bool> DeleteAccommodation(int id)
        {
            return await _accommodationRepository.DeleteAccommodation(id);
        }
    }
}
