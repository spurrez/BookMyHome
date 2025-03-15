using BookMyHome.Application.Interfaces;
using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Services.BookingService.Interfaces;
using BookMyHome.Domain.Entities;
using BookMyHome.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyHome.BlazorWebApp.Server.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingQueries _bookingQueries;
        private readonly IBookingCommands _bookingCommands;

        public BookingController(IBookingQueries bookingQueries, IBookingCommands bookingCommands)
        {
            _bookingCommands = bookingCommands;
            _bookingQueries = bookingQueries;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bookings = await _bookingQueries.GetAllBookings();
            if (bookings == null || !bookings.Any())
                return NotFound("Bookings are empty");
            return Ok(bookings);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var booking = await _bookingQueries.GetBookingById(id);
            if (booking == null)
                return NotFound($"Did not find the booking with id: {id}");
            return Ok(booking);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post(Booking booking)
        {
            var createdBooking = await _bookingCommands.CreateBooking(booking);
            if (createdBooking == null)
                return BadRequest("Failed to create booking");
            return Ok(createdBooking);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Booking booking)
        {
            var updatedBooking = await _bookingCommands.UpdateBooking(id, booking);
            if (updatedBooking == null)
                return BadRequest("Failed to update booking");
            return Ok(updatedBooking);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deletedBooking = await _bookingCommands.DeleteBooking(id);
            if (!deletedBooking)
            {
                return NotFound($"The booking with id: {id} could not be found");
            }
            return NoContent();
        }
    }
}