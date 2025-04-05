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
        Task<GuestUser> CreateGuest(GuestUser guest);
        Task<GuestUser> UpdateGuest(int id, GuestUser guest);
        Task<bool> DeleteGuest(int id);
    }
}
