using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
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

        public AccommodationType TypeOfAccommodation { get; set; }

		public string? Amenities { get; set; }
		//public string? Photos { get; set; }
		public bool Availability { get; set; } = true;
		public string? HouseRules { get; set; }

		//[NotMapped] // Don't store in DB, calculate dynamically
		//public decimal AverageRating => Reviews.Any() ? Reviews.Average(r => r.Rating) : 0;

		// Foreign key: An Accommodation belongs to one Host
		public int? HostId { get; set; }
		public HostUser? Host { get; set; }

		public List<Review> Reviews { get; set; } = new();

		[Timestamp]
		public byte[]? RowVersion { get; set; }


		public enum AccommodationType
		{
			House,
			Apartment,
			Villa,
			Cabin,
			Cottage,
			Loft,
			Chalet
		}
	}
}
