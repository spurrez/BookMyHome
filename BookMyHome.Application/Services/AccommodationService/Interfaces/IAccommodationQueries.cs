using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.AccommodationService.Interfaces
{
    public interface IAccommodationQueries
	{
        Task<IEnumerable<Accommodation>?> GetAllAccommodation();
        Task<Accommodation?> GetAccommodationById(int id);
        Task<IEnumerable<Accommodation>?> GetAllAccommodationsByHost(int id);
    }
}
