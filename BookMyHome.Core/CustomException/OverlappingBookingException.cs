using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.CustomException
{
	public class OverlappingBookingException : Exception
	{
        public OverlappingBookingException()
            :base("The booking overlaps with another.")
        {
            
        }
    }
}
