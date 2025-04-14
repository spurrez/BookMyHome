using BookMyHome.Application.DTO;
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

            var bookingDtos = bookings.Select(b => new BookingDTO
            {
                BookingId = b.BookingId,
                CheckIn = b.CheckIn,
                CheckOut = b.CheckOut,
                SpecialRequests = b.SpecialRequests,
                AccommodationId = b.AccommodationId,
                GuestAmount = b.GuestAmount
            }).ToList();
			return Ok(bookingDtos);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var booking = await _bookingQueries.GetBookingById(id);
            if (booking == null)
                return NotFound($"Did not find the booking with id: {id}");

			var bookingDto = new BookingDTO
			{
				BookingId = booking.BookingId,
				CheckIn = booking.CheckIn,
				CheckOut = booking.CheckOut,
		
				SpecialRequests = booking.SpecialRequests,
				AccommodationId = booking.AccommodationId,
				GuestAmount = booking.GuestAmount
			};
			return Ok(bookingDto);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post(BookingDTO bookingDto)
        {
			var booking = new Booking
			{
				BookingId = bookingDto.BookingId,
				CheckIn = bookingDto.CheckIn,
				CheckOut = bookingDto.CheckOut,
				
				SpecialRequests = bookingDto.SpecialRequests,
				AccommodationId = bookingDto.AccommodationId,
				GuestAmount = bookingDto.GuestAmount
			};

			var createdBooking = await _bookingCommands.CreateBooking(booking);
            if (createdBooking == null)
                return BadRequest("Failed to create booking");

			var createdBookingDto = new BookingDTO
			{
				BookingId = createdBooking.BookingId,
				CheckIn = createdBooking.CheckIn,
				CheckOut = createdBooking.CheckOut,
				
				SpecialRequests = createdBooking.SpecialRequests,
				AccommodationId = createdBooking.AccommodationId,
				GuestAmount = createdBooking.GuestAmount
			};
			return Ok(createdBookingDto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BookingDTO bookingDto)
        {
            var booking = new Booking
            {
                BookingId = bookingDto.BookingId,
                CheckIn = bookingDto.CheckIn,
                CheckOut = bookingDto.CheckOut,
                
                SpecialRequests = bookingDto.SpecialRequests,
                AccommodationId = bookingDto.AccommodationId,
                GuestId = bookingDto.GuestId
            };


            var updatedBooking = await _bookingCommands.UpdateBooking(id, booking);
            if (updatedBooking == null)
                return BadRequest("Failed to update booking");

            var updatedBookingDto = new BookingDTO
            {
                BookingId = updatedBooking.BookingId,
                CheckIn = updatedBooking.CheckIn,
                CheckOut = updatedBooking.CheckOut,
                
                SpecialRequests = updatedBooking.SpecialRequests,
                AccommodationId = updatedBooking.AccommodationId,
                GuestId = updatedBooking.GuestId
            };

            return Ok(updatedBookingDto);
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