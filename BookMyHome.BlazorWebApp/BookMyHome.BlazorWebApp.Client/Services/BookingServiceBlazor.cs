using BookMyHome.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.BlazorWebApp.Client.Interfaces;
using BookMyHome.Application.DTO;

namespace BookMyHome.BlazorWebApp.Client.Services
{
	public class BookingServiceBlazor : IBookingServiceBlazor
	{
		private readonly HttpClient httpClient;
		public BookingServiceBlazor(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}
		public async Task<IEnumerable<BookingDTO>?> GetAllBookings()
		{
			var result = await httpClient.GetFromJsonAsync<BookingDTO[]>("api/booking");
			return result ?? Array.Empty<BookingDTO>();
		}

		public async Task<BookingDTO?> GetBookingById(int id)
		{
			var result = await httpClient.GetFromJsonAsync<BookingDTO>($"api/booking/{id}");
			return result;
		}
		public async Task<BookingDTO> CreateBooking(BookingDTO booking)
		{
			var response = await httpClient.PostAsJsonAsync("api/booking", booking);

			// Make sure the request was successful
			response.EnsureSuccessStatusCode();

			// Deserialize the response body to a Booking object
			var createdBooking = await response.Content.ReadFromJsonAsync<BookingDTO>();
			return createdBooking;
		}

		public async Task<BookingDTO> UpdateBooking(int id, BookingDTO booking)
		{
			var response = await httpClient.PutAsJsonAsync($"api/booking/{id}", booking);
			response.EnsureSuccessStatusCode();
			var updatedBooking = await response.Content.ReadFromJsonAsync<BookingDTO>();
			return updatedBooking;
		}

		public async Task<bool> DeleteBooking(int id)
		{
			var response = await httpClient.DeleteAsync($"api/booking/{id}");
			return response.IsSuccessStatusCode;
		}
	}

}

