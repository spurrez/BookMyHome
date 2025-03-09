using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.AccommodationService.Interfaces
{
    public interface IAccommodationCommands
	{
        Task<Accommodation> CreateAccommodation(Accommodation booking);
        Task<Accommodation> UpdateAccommodation(int id, Accommodation booking);
        Task<bool> DeleteAccommodation(int id);
    }
}
