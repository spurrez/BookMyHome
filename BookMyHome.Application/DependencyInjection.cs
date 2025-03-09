using BookMyHome.Application.Services.BookingService.Commands;
using BookMyHome.Application.Services.BookingService.Interfaces;
using BookMyHome.Application.Services.BookingService.Queries;
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
			services.AddScoped<IBookingCommands, BookingCommandsService>();
			services.AddScoped<IBookingQueries, BookingQueriesService>();
			return services;
		}
	}
}
