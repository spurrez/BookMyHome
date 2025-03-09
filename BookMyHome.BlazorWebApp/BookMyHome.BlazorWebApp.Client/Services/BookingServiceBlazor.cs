using BookMyHome.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.BlazorWebApp.Client.Interfaces;

namespace BookMyHome.Application.Services
{
	public class BookingServiceBlazor : IBookingServiceBlazor
	{
		private readonly HttpClient httpClient;
		public BookingServiceBlazor(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}
		public async Task<IEnumerable<Booking>?> GetAllBookings()
		{
			var result = await httpClient.GetFromJsonAsync<Booking[]>("api/booking");
			return result ?? Array.Empty<Booking>();
		}

		public async Task<Booking?> GetBookingById(Guid id)
		{
			var result = await httpClient.GetFromJsonAsync<Booking>($"api/booking/{id}");
			return result;
		}
		public async Task<Booking> CreateBooking(Booking booking)
		{
			var response = await httpClient.PostAsJsonAsync("api/booking", booking);

			// Make sure the request was successful
			response.EnsureSuccessStatusCode();

			// Deserialize the response body to a Booking object
			var createdBooking = await response.Content.ReadFromJsonAsync<Booking>();
			return createdBooking;
		}

		public async Task<Booking> UpdateBooking(Guid id, Booking booking)
		{
			var response = await httpClient.PutAsJsonAsync<Booking>($"api/booking/{id}", booking);
			response.EnsureSuccessStatusCode();
			var updatedBooking = await response.Content.ReadFromJsonAsync<Booking>();
			return updatedBooking;
		}

		public async Task<bool> DeleteBooking(Guid id)
		{
			var response = await httpClient.DeleteAsync($"api/booking/{id}");
			return response.IsSuccessStatusCode;
		}
	}

}

