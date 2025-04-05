using BookMyHome.Application.Services.AccommodationService.Interfaces;
using BookMyHome.Application.Services.BookingService.Interfaces;
using BookMyHome.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyHome.BlazorWebApp.Server.ApiController
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccommodationController : ControllerBase
	{
		private readonly IAccommodationQueries _accommodationQueries;
		private readonly IAccommodationCommands _accommodationCommands;
        public AccommodationController(IAccommodationQueries accommodationQueries, IAccommodationCommands accommodationCommands)
        {
			_accommodationQueries = accommodationQueries;
            _accommodationCommands = accommodationCommands;
        }

        [HttpGet]
		public async Task<IActionResult> Get()
		{
			var accommodations = await _accommodationQueries.GetAllAccommodation();
			if(accommodations == null || !accommodations.Any()) 
				return NotFound("Accommodations are empty");
			return Ok(accommodations);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var accommodations = await _accommodationQueries.GetAccommodationById(id);
			if (accommodations == null)
				return NotFound("Did not find the accommodation");
			return Ok(accommodations);
		}

		[HttpGet("host/{hostId}")]
		public async Task<IActionResult> GetHostAccommodations(int hostId)
		{
			var accommodations = await _accommodationQueries.GetAllAccommodationsByHost(hostId);
			if (accommodations == null || !accommodations.Any())
				return NotFound("Did not find any accommodations by this host");
			return Ok(accommodations);
		}

		[HttpPost]
		public async Task<IActionResult> Post(Accommodation accommodation)
		{
			var createdAccommodations = await _accommodationCommands.CreateAccommodation(accommodation);
			if (createdAccommodations == null)
				return NotFound("Failed to create");
			return Ok(createdAccommodations);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Accommodation accommodation)
		{
			var updatedBooking = await _accommodationCommands.UpdateAccommodation(id, accommodation);
			if (updatedBooking == null)
				return NotFound("Failed to update");
			return Ok(updatedBooking);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			bool deletedAccommodation = await _accommodationCommands.DeleteAccommodation(id);
			if (!deletedAccommodation)
				return NotFound("Failed to delete");
			return NoContent();
		}
	}
}
