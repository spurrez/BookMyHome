using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookMyHome.Application.Interfaces.ReposInterfaces
{
    public interface IAccommodationRepository
    {
		Task<IEnumerable<Accommodation>?> GetAllAccommodations();
		Task<Accommodation?> GetAccommodationById(int id);
		Task<Accommodation> CreateAccommodation(Accommodation acco);
		Task<Accommodation> UpdateAccommodation(int id, Accommodation acco);
		Task<bool> DeleteAccommodation(int id);

	}
}
