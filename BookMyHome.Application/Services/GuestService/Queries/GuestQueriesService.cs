using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Services.GuestService.Interfaces;
using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.GuestService.Queries
{
    public class GuestQueriesService : IGuestQueries
    {
        private readonly IGuestRepository _guestRepository;

        public GuestQueriesService(IGuestRepository guestRepository)
        {
			_guestRepository = guestRepository;
        }
        public async Task<IEnumerable<GuestUser>?> GetAllGuests()
        {
            return await _guestRepository.GetAllGuests();
        }

        public async Task<GuestUser?> GetGuestById(int id)
        {
            return await _guestRepository.GetGuestById(id);
        }

    }
}
