using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BookMyHome.Domain.Entities
{
	public class Booking
	{
		[Key]
		public int BookingId { get; set; }
		[Required]
		public DateTime CheckIn { get; set; }
		[Required]
		public DateTime CheckOut { get; set; }
		public BookingStatus Status { get; set; } = BookingStatus.Pending;

		[Required]
		public int GuestAmount { get; set; }
		public string? SpecialRequests { get; set; }

		//public int? GuestRating { get; set; }  // Rating given to the guest
		//public int? HostRating { get; set; }   // Rating given to the host
		//public string? GuestReview { get; set; }
		//public string? HostReview { get; set; }
		//public bool IsPaid { get; set; } = false;


		// Foreign key: A Booking is associated with one Accommodation
		public int AccommodationId { get; set; }
		public Accommodation Accommodation { get; set; }

		// Foreign key: A Booking is made by one Guest
		public int GuestId { get; set; }
		public GuestUser Guest { get; set; }


        [Timestamp]
        public byte[]? RowVersion { get; set; }


        public Booking(DateTime checkIn, DateTime checkOut)
		{
			if (checkIn == default)
				throw new ArgumentOutOfRangeException(nameof(checkIn), "Check In date has to be filled out");
			if (checkOut == default)
				throw new ArgumentOutOfRangeException(nameof(checkOut), "Check Out date has to be filled out");

			// Booking sker på dato - dvs. uden tidspunkt.
			CheckIn = checkIn.Date; // add date to ensure no time 
			CheckOut = checkOut.Date;

			// Man kan ikke booke i fortiden.
			if (CheckIn < DateTime.Now.Date)
				throw new Exception("Cannot book in the past");

			//Slutdato skal ligge efter startdato
			if (checkIn >= checkOut)
				throw new Exception("Check out date has to be on a later date than check in");
		}
        public Booking()
        {
        }

		// This checks if the check-in date of the current booking is before the check-out date of the existing booking.
		// In other words, the current booking starts before the other booking ends and vice versa.
		public bool IsOverLapping(IEnumerable<Booking> existingBookings)
		{
			return existingBookings.Any(existingBooking =>
				CheckIn < existingBooking.CheckOut && CheckOut > existingBooking.CheckIn
			);
		}
		public enum BookingStatus
		{
			Pending,    // Awaiting host approval
			Confirmed,  // Approved by host or auto-confirmed
			Declined,   // Rejected by host
			Cancelled,  // Cancelled by guest or host
			Completed   // Stay completed
		}


	}
}
