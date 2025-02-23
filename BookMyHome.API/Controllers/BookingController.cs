using BookMyHome.Application.Interfaces;
using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Core.Entities;
using BookMyHome.Infrastructure.Persistence.Interfaces;
using BookMyHome.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyHome.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
			_bookingRepository = bookingRepository;
        }

        // GET: api/<ValuesController>
        [HttpGet]
		public async Task<IActionResult> Get()
		{
			var bookings =  await _bookingRepository.GetAllBookings();
			if (bookings == null || !bookings.Any())
				return NotFound("Bookings are empty");
			return Ok(bookings);
		}

		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var booking = await _bookingRepository.GetBookingById(id);
			if(booking == null)
				return NotFound($"Did not find the booking with id: {id}");
			return Ok(booking);
		}

		// POST api/<ValuesController>
		[HttpPost]
		public async Task<IActionResult> Post(Booking booking)
		{
			var createdBooking = await _bookingRepository.CreateBooking(booking);
			if (createdBooking == null)
				return BadRequest("Failed to create booking");
			return Ok(createdBooking);
		}

		// PUT api/<ValuesController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, Booking booking)
		{
			var updatedBooking = await _bookingRepository.UpdateBooking(id, booking);
			if (updatedBooking == null)
				return BadRequest("Failed to update booking");
			return Ok(updatedBooking);
		}

		// DELETE api/<ValuesController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			bool deletedBooking = await _bookingRepository.DeleteBooking(id);
			if (!deletedBooking)
			{
				return NotFound($"The booking with id: {id} could not be found");
			}
			return NoContent();
		}
	}
}
