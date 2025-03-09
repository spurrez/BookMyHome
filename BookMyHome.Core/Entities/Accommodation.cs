using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.Entities
{
	public class Accommodation
	{
		[Key]
        public int AccommodationId { get; set; }
		[Required, StringLength(100)]
		public string? Title { get; set; }
		public string? Description { get; set; }
		[Required, StringLength(100)]
		public string? Address { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal PricePerNight { get; set; }

        // Foreign key: An Accommodation belongs to one Host
        public int HostId { get; set; }
		public virtual Host Owner { get; set; }

		// Navigation property: An Accommodation can have many Bookings
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
		[Timestamp]
		public byte[]? RowVersion { get; set; }
	}
}
