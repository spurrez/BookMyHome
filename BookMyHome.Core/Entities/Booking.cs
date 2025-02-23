using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BookMyHome.Core.Entities
{
	public class Booking
	{
		//public IServiceProvider? ServiceProvider { get; set; }

		[Key]
		public Guid BookingId { get; set; }
		public DateTime CheckIn { get; set; }
		public DateTime CheckOut { get; set; }


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

			//En booking er fra og med startdato til og med slutdato
			//Slutdato skal ligge efter startdato
			if (checkIn >= checkOut)
				throw new Exception("Check out date has to be on a later date than check in");

			//ServiceProvider = serviceProvider;

			BookingId = Guid.NewGuid();
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

	}
}
