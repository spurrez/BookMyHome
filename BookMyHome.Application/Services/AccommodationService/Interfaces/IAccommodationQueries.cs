using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.BookingService.Interfaces
{
    public interface IAccommodationQueries
	{
        Task<IEnumerable<Accommodation>?> GetAllAccommodation();
        Task<Accommodation?> GetAccommodationById(int id);
    }
}
