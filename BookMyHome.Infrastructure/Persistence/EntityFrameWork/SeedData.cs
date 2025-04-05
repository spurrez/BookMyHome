using BookMyHome.Domain.Entities;
using BookMyHome.Infrastructure.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookMyHome.Infrastructure
{
	public static class SeedData
	{
		//public static void InitializeSeedData(IServiceProvider serviceProvider, EntityFrameworkDBContext context)
		//{
		//	// Prevent seeding if the data already exists
		//	if (context.Hosts.Any()) return;  // If Users (Host/Guest) are already in the database, do not seed
		//	if (context.Guests.Any()) return;
		//	if (context.Bookings.Any()) return;

		//	// Seed Hosts
		//	var host1 = new HostUser
		//	{
		//		FirstName = "John",
		//		LastName = "Doe",
		//		Email = "john.doe@example.com",
		//		Password = "Host123!", // Ideally hashed before storing
		//		Phone = "1234567890"
		//	};

		//	var host2 = new HostUser
		//	{
		//		FirstName = "Jane",
		//		LastName = "Smith",
		//		Email = "jane.smith@example.com",
		//		Password = "Host456!",
		//		Phone = "0987654321"
		//	};

		//	context.Hosts.AddRange(host1, host2);  // Add Hosts to the Users table
		//	context.SaveChanges();

		//	// Seed Guests
		//	var guest1 = new GuestUser
		//	{
		//		FirstName = "Alice",
		//		LastName = "Johnson",
		//		Email = "alice.johnson@example.com",
		//		Password = "Guest123!",
		//		Phone = "1122334455"
		//	};

		//	var guest2 = new GuestUser
		//	{
		//		FirstName = "Bob",
		//		LastName = "Brown",
		//		Email = "bob.brown@example.com",
		//		Password = "Guest456!",
		//		Phone = "6677889900"
		//	};

		//	context.Guests.AddRange(guest1, guest2);  // Add Guests to the Users table
		//	context.SaveChanges();

		//	// Seed Accommodations
		//	var accommodation1 = new Accommodation
		//	{
		//		Title = "Ocean View Villa",
		//		Description = "A beautiful villa with an ocean view.",
		//		Address = "123 Ocean Drive, Beach Town",
		//		PricePerNight = 150m,
		//		HostId = 1  // John Doe is the host
		//	};

		//	var accommodation2 = new Accommodation
		//	{
		//		Title = "Mountain Retreat",
		//		Description = "A peaceful retreat in the mountains.",
		//		Address = "456 Mountain Rd, Hilltop",
		//		PricePerNight = 100m,
		//		HostId = 2  // Jane Smith is the host
		//	};

		//	context.Accommodations.AddRange(accommodation1, accommodation2);  // Add Accommodations
		//	context.SaveChanges();

		//	// Seed Bookings
		//	var booking1 = new Booking
		//	{
		//		CheckIn = new DateTime(2025, 6, 15),
		//		CheckOut = new DateTime(2025, 6, 20),
		//		AccommodationId = 1,
		//		GuestId = 1  // Alice Johnson booked the Ocean View Villa
		//	};

		//	var booking2 = new Booking
		//	{
		//		CheckIn = new DateTime(2025, 7, 10),
		//		CheckOut = new DateTime(2025, 7, 15),
		//		AccommodationId = 2,
		//		GuestId = 2  // Bob Brown booked the Mountain Retreat
		//	};

		//	context.Bookings.AddRange(booking1, booking2);  // Add Bookings

		//	// Save all data to the database
		//	context.SaveChanges();
		//}
	}
}
