using BookMyHome.Core.Entities;
using Microsoft.EntityFrameworkCore;
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
		public DbSet<Host> Hosts { get; set; }
		public DbSet<Booking> Bookings { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			modelBuilder.Entity<Booking>()
			.HasData(
				new Booking(new DateTime(2025, 04, 30), new DateTime(2025, 05, 3)) { BookingId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
				new Booking(new DateTime(2025, 06, 20), new DateTime(2025, 07, 2)) { BookingId = Guid.Parse("22222222-2222-2222-2222-222222222222") }
			);
		}
	}
}
