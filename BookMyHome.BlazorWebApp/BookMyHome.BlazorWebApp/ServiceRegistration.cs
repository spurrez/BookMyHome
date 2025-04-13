using BookMyHome.BlazorWebApp.Client.Interfaces;
using BookMyHome.BlazorWebApp.Client.Services;

namespace BookMyHome.BlazorWebApp.Server
{
	public static class ServiceRegistration
	{
		public static void AddClientServices(this IServiceCollection services, string backendUrl)
		{
			//services.AddScoped<IBookingServiceBlazor, BookingServiceBlazor>();

			services.AddHttpClient<IBookingServiceBlazor, BookingServiceBlazor>(client =>
			{
				client.BaseAddress = new Uri(backendUrl);  // Backend URL (if necessary)
			});

			// services.AddScoped<ISomeServerService, SomeServerService>();
		}
	}
}
