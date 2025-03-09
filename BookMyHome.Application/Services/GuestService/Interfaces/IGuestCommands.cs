using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.GuestService.Interfaces
{
    public interface IGuestCommands
    {
        Task<Guest> CreateGuest(Guest guest);
        Task<Guest> UpdateGuest(int id, Guest guest);
        Task<bool> DeleteGuest(int id);
    }
}
