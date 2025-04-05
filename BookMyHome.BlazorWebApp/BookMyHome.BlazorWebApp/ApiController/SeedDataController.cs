using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Domain.Entities;
using BookMyHome.Infrastructure;
using BookMyHome.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyHome.BlazorWebApp.Server.ApiController
{
	[Route("api/[controller]")]
	[ApiController]
	public class SeedDataController : ControllerBase
	{
		IBookingRepository _bookingRepository;
		IAccommodationRepository _accommodationRepository;
		IHostRepository _hostRepository;
		IGuestRepository _guestRepository;

		public SeedDataController
			(IBookingRepository bookingRepository,
			IAccommodationRepository accommodationRepository,
			IHostRepository hostRepository,
			IGuestRepository guestRepository)
		{
			_bookingRepository = bookingRepository;
			_accommodationRepository = accommodationRepository;
			_hostRepository = hostRepository;
			_guestRepository = guestRepository;
		}

		[HttpGet]
		public async Task SeedData()
		{
			// Seed Hosts
			var host1 = new HostUser
			{
				FirstName = "John",
				LastName = "Doe",
				Email = "john.doe@example.com",
				Password = "Host123!", // Ideally hashed before storing
				Phone = "1234567890"
			};

			var host2 = new HostUser
			{
				FirstName = "Jane",
				LastName = "Smith",
				Email = "jane.smith@example.com",
				Password = "Host456!",
				Phone = "0987654321"
			};

			var host3 = new HostUser
			{
				FirstName = "Michael",
				LastName = "Johnson",
				Email = "michael.johnson@example.com",
				Password = "Host789!",
				Phone = "1122334455"
			};

			var host4 = new HostUser
			{
				FirstName = "Emily",
				LastName = "Williams",
				Email = "emily.williams@example.com",
				Password = "Host101112!",
				Phone = "2233445566"
			};

			var host5 = new HostUser
			{
				FirstName = "Oliver",
				LastName = "Davis",
				Email = "oliver.davis@example.com",
				Password = "Host131415!",
				Phone = "3344556677"
			};

			await _hostRepository.CreateHost(host1);
			await _hostRepository.CreateHost(host2);
			await _hostRepository.CreateHost(host3);
			await _hostRepository.CreateHost(host4);
			await _hostRepository.CreateHost(host5);

			// Seed Guests
			var guest1 = new GuestUser
			{
				FirstName = "Alice",
				LastName = "Johnson",
				Email = "alice.johnson@example.com",
				Password = "Guest123!",
				Phone = "1122334455"
			};

			var guest2 = new GuestUser
			{
				FirstName = "Bob",
				LastName = "Brown",
				Email = "bob.brown@example.com",
				Password = "Guest456!",
				Phone = "6677889900"
			};

			var guest3 = new GuestUser
			{
				FirstName = "Charlie",
				LastName = "Davis",
				Email = "charlie.davis@example.com",
				Password = "Guest789!",
				Phone = "4455667788"
			};

			var guest4 = new GuestUser
			{
				FirstName = "David",
				LastName = "Martinez",
				Email = "david.martinez@example.com",
				Password = "Guest1011!",
				Phone = "5566778899"
			};

			var guest5 = new GuestUser
			{
				FirstName = "Eva",
				LastName = "Taylor",
				Email = "eva.taylor@example.com",
				Password = "Guest1213!",
				Phone = "6677889900"
			};

			await _guestRepository.CreateGuest(guest1);
			await _guestRepository.CreateGuest(guest2);
			await _guestRepository.CreateGuest(guest3);
			await _guestRepository.CreateGuest(guest4);
			await _guestRepository.CreateGuest(guest5);

			// Seed Accommodations
			var retrievedHost1 = await _hostRepository.GetHostByName("John", "Doe");
			var retrievedHost2 = await _hostRepository.GetHostByName("Jane", "Smith");
			var retrievedHost3 = await _hostRepository.GetHostByName("Michael", "Johnson");
			var retrievedHost4 = await _hostRepository.GetHostByName("Emily", "Williams");
			var retrievedHost5 = await _hostRepository.GetHostByName("Oliver", "Davis");

			var accommodation1 = new Accommodation
			{
				Title = "Mountain Retreat",
				Description = "A peaceful retreat in the mountains.",
				Address = "456 Mountain Rd, Hilltop",
				PricePerNight = 100m,
				TypeOfAccommodation = Accommodation.AccommodationType.Cabin,
				Amenities = "Free WiFi, Hot Tub, Fireplace, Hiking Trails Nearby, Fully Equipped Kitchen",
				Availability = true,
				HouseRules = "No smoking. No pets. Quiet hours: 10 PM - 7 AM.",
				HostId = retrievedHost2.UserId
			};

			var accommodation2 = new Accommodation
			{
				Title = "Ocean View Villa",
				Description = "A beautiful villa with an ocean view.",
				Address = "123 Ocean Drive, Beach Town",
				PricePerNight = 150m,
				TypeOfAccommodation = Accommodation.AccommodationType.Villa,
				Amenities = "Beach Access, Private Pool, Air Conditioning, Oceanfront Balcony, BBQ Grill",
				Availability = true,
				HouseRules = "No loud music after 10 PM. No parties or events. Clean up after yourself.",
				HostId = retrievedHost1.UserId
			};

			var accommodation3 = new Accommodation
			{
				Title = "City Loft",
				Description = "A modern and spacious loft in the heart of the city.",
				Address = "789 City Blvd, Downtown",
				PricePerNight = 200m,
				TypeOfAccommodation = Accommodation.AccommodationType.Loft,
				Amenities = "WiFi, Gym Access, Modern Kitchen, Parking Available",
				Availability = true,
				HouseRules = "No smoking. No pets.",
				HostId = retrievedHost3.UserId
			};

			var accommodation4 = new Accommodation
			{
				Title = "Seaside Cottage",
				Description = "Cozy cottage with a view of the sea.",
				Address = "321 Seaside Ave, Coastal Town",
				PricePerNight = 120m,
				TypeOfAccommodation = Accommodation.AccommodationType.Cottage,
				Amenities = "Beach Access, BBQ Grill, Seafront Balcony",
				Availability = true,
				HouseRules = "Quiet hours after 9 PM.",
				HostId = retrievedHost4.UserId
			};

			var accommodation5 = new Accommodation
			{
				Title = "Riverside Chalet",
				Description = "A luxurious chalet with a riverside view.",
				Address = "987 River Rd, Forest Hills",
				PricePerNight = 180m,
				TypeOfAccommodation = Accommodation.AccommodationType.Chalet,
				Amenities = "Private Pool, Fireplace, Outdoor Dining Area, Fishing Dock",
				Availability = true,
				HouseRules = "No loud parties. Clean up after yourself.",
				HostId = retrievedHost5.UserId
			};

			await _accommodationRepository.CreateAccommodation(accommodation1);
			await _accommodationRepository.CreateAccommodation(accommodation2);
			await _accommodationRepository.CreateAccommodation(accommodation3);
			await _accommodationRepository.CreateAccommodation(accommodation4);
			await _accommodationRepository.CreateAccommodation(accommodation5);

			// Seed Bookings
			var retrievedGuest1 = await _guestRepository.GetGuestByName("Alice", "Johnson");
			var retrievedGuest2 = await _guestRepository.GetGuestByName("Bob", "Brown");
			var retrievedGuest3 = await _guestRepository.GetGuestByName("Charlie", "Davis");
			var retrievedAccommodation1 = await _accommodationRepository.GetAccommodationByTitle("Ocean View Villa");
			var retrievedAccommodation2 = await _accommodationRepository.GetAccommodationByTitle("Mountain Retreat");
			var retrievedAccommodation3 = await _accommodationRepository.GetAccommodationByTitle("City Loft");

			var booking1 = new Booking
			{
				CheckIn = new DateTime(2025, 6, 15),
				CheckOut = new DateTime(2025, 6, 20),
				Status = Booking.BookingStatus.Completed,
				GuestAmount = 1,
				AccommodationId = retrievedAccommodation1.AccommodationId,
				GuestId = retrievedGuest1.UserId
			};

			var booking2 = new Booking
			{
				CheckIn = new DateTime(2025, 7, 10),
				CheckOut = new DateTime(2025, 7, 15),
				Status = Booking.BookingStatus.Completed,
				GuestAmount = 3,
				SpecialRequests = "Please don't clean my room",
				AccommodationId = retrievedAccommodation2.AccommodationId,
				GuestId = retrievedGuest2.UserId
			};

			var booking3 = new Booking
			{
				CheckIn = new DateTime(2025, 8, 5),
				CheckOut = new DateTime(2025, 8, 10),
				Status = Booking.BookingStatus.Pending,
				GuestAmount = 2,
				AccommodationId = retrievedAccommodation3.AccommodationId,
				GuestId = retrievedGuest3.UserId
			};

			await _bookingRepository.CreateBooking(booking1);
			await _bookingRepository.CreateBooking(booking2);
			await _bookingRepository.CreateBooking(booking3);
		}
	}
}
