using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookMyHome.Application.Interfaces.ReposInterfaces
{
    public interface IGuestRepository
	{
		Task<IEnumerable<GuestUser>?> GetAllGuests();
		Task<GuestUser?> GetGuestById(int id);
		Task<GuestUser> CreateGuest(GuestUser guest);
		Task<GuestUser> UpdateGuest(int id, GuestUser guest);
		Task<bool> DeleteGuest(int id);
		Task<GuestUser?> GetGuestByName(string firstName, string lastName);

	}
}
