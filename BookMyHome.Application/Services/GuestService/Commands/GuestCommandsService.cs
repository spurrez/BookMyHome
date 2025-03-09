using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Services.GuestService.Interfaces;
using BookMyHome.Domain.CustomException;
using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.GuestService.Commands
{
    public class GuestCommandsService : IGuestCommands
    {

        private readonly IGuestRepository _guestRepository;

        public GuestCommandsService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<Guest> CreateGuest(Guest guest)
        {
            return await _guestRepository.CreateGuest(guest);
        }

        public async Task<Guest> UpdateGuest(int id, Guest guest)
        {
            return await _guestRepository.UpdateGuest(id, guest);
        }

        public async Task<bool> DeleteGuest(int id)
        {
            return await _guestRepository.DeleteGuest(id);
        }
    }
}
