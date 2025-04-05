using BookMyHome.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Infrastructure.EntityFrameWork
{
	public class EntityFrameworkDBContext : DbContext
	{
		public EntityFrameworkDBContext(DbContextOptions<EntityFrameworkDBContext> options)
			: base(options)
		{
		}
        public DbSet<HostUser> Hosts { get; set; }
		public DbSet<Booking> Bookings { get; set; }
        public DbSet<GuestUser> Guests { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
		
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Booking>()
			//	.HasData(
			//		new Booking(new DateTime(2025, 04, 30), new DateTime(2025, 05, 3)) { BookingId = 1},
			//		new Booking(new DateTime(2025, 06, 20), new DateTime(2025, 07, 2)) { BookingId = 2}
			//	);
		}

	}
}
