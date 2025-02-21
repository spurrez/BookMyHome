using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Core
{
	internal class Booking
	{
        public int BookingId { get; set; }
		public DateOnly CheckIn { get; set; }
		public DateOnly CheckOut { get; set; }

    }
}
