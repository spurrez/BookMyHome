using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Services.AccommodationService.Interfaces;
using BookMyHome.Application.Services.BookingService.Interfaces;
using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.AccommodationService.Queries
{
    public class AccommodationQueriesService : IAccommodationQueries
	{
        private readonly IAccommodationRepository _accommodationRepository;

        public AccommodationQueriesService(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }
        public async Task<IEnumerable<Accommodation>?> GetAllAccommodation()
        {
            return await _accommodationRepository.GetAllAccommodations();
        }

        public async Task<IEnumerable<Accommodation>?> GetAllAccommodationsByHost(int id)
        {
            return await _accommodationRepository.GetAllAccommodationsByHost(id);
        }

        public async Task<Accommodation?> GetAccommodationById(int id)
        {
            return await _accommodationRepository.GetAccommodationById(id);
        }

    }
}
