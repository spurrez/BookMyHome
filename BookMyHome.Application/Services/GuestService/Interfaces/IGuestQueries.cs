using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.GuestService.Interfaces
{
    public interface IGuestQueries
    {
        Task<IEnumerable<Guest>?> GetAllGuests();
        Task<Guest?> GetGuestById(int id);
    }
}
