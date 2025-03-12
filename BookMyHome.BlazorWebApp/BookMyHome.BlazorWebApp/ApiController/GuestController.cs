using BookMyHome.Application.Services.AccommodationService.Interfaces;
using BookMyHome.Application.Services.BookingService.Interfaces;
using BookMyHome.Application.Services.GuestService.Interfaces;
using BookMyHome.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyHome.BlazorWebApp.Server.ApiController
{
	[Route("api/[controller]")]
	[ApiController]
	public class GuestController : ControllerBase
	{
		private readonly IGuestQueries _guestQueries;
		private readonly IGuestCommands _guestCommands;
        public GuestController(IGuestQueries guestQueries, IGuestCommands guestCommands)
        {
            _guestQueries = guestQueries;
			_guestCommands = guestCommands;
        }

        [HttpGet]
		public async Task<IActionResult> Get()
		{
			var guests = await _guestQueries.GetAllGuests();
			if (guests == null || !guests.Any())
				return NotFound("Guests are empty");
			return Ok(guests);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var accommodations = await _guestQueries.GetGuestById(id);
			if (accommodations == null)
				return NotFound("Did not find the accommodation");
			return Ok(accommodations);
		}

		[HttpPost]
		public async Task<IActionResult> Post(Guest guest)
		{
			var createdGuest = await _guestCommands.CreateGuest(guest);
			if (createdGuest == null)
				return NotFound("Failed to create");
			return Ok(createdGuest);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Guest guest)
		{
			var updatedGuest = await _guestCommands.UpdateGuest(id, guest);
			if (updatedGuest == null)
				return NotFound("Failed to update");
			return Ok(updatedGuest);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			bool deletedGuest = await _guestCommands.DeleteGuest(id);
			if (!deletedGuest)
				return NotFound("Failed to delete");
			return NoContent();
		}
	}
}
