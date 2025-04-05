using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BookMyHome.Domain.Entities
{
	public class Review
    {
        public int ReviewId { get; set; }
        [Range(1,5)]
        [Required]
        public int Rating { get; set; }
        [MaxLength(50)]
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Foreign keys
        public int AccommodationId { get; set; }
		public Accommodation? Accommodation { get; set; }
	}
}
