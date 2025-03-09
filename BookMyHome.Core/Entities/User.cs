using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.Entities
{
    public abstract class User
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(25)]

        public string? FirstName { get; set; }
        [Required, StringLength(25)]
        public string? LastName { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required, StringLength(100, MinimumLength = 6)]
        public string? Password { get; set; }
        [Required]// maybe max and min and only dash and numbers]
        public string? Phone { get; set; }
		[Timestamp]
		public byte[]? RowVersion { get; set; }
	}
}
