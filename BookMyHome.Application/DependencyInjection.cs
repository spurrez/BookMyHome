using BookMyHome.Application.Interfaces.ServicesInterfaces;
using BookMyHome.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application
{
    public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddScoped<IBookingService, BookingService>();
			return services;
		}
	}
}
