using BookMyHome.BlazorWebApp.Client.Interfaces;
using BookMyHome.BlazorWebApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BookMyHome.BlazorWebApp.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);


			//NOT SURE IF THIS IS NEEDED. chatgpt seems to think so but i dont see it
			//builder.Services.AddHttpClient<IBookingServiceBlazor, BookingServiceBlazor>(client =>
			//{
			//	client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
			//});

			//// Add other services as needed (e.g., Navigation, State, etc.)
			//builder.Services.AddScoped<IBookingServiceBlazor, BookingServiceBlazor>();



			await builder.Build().RunAsync();
        }
    }
}