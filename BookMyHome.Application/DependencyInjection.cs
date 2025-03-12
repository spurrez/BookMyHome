using BookMyHome.Application.Services.AccommodationService.Commands;
using BookMyHome.Application.Services.AccommodationService.Interfaces;
using BookMyHome.Application.Services.AccommodationService.Queries;
using BookMyHome.Application.Services.BookingService.Commands;
using BookMyHome.Application.Services.BookingService.Interfaces;
using BookMyHome.Application.Services.BookingService.Queries;
using BookMyHome.Application.Services.GuestService.Commands;
using BookMyHome.Application.Services.GuestService.Interfaces;
using BookMyHome.Application.Services.GuestService.Queries;
using BookMyHome.Application.Services.HostService.Commands;
using BookMyHome.Application.Services.HostService.Interfaces;
using BookMyHome.Application.Services.HostService.Queries;
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

			services.AddScoped<IHostCommands, HostCommandsService>();
			services.AddScoped<IHostQueries, HostQueriesService>();

			services.AddScoped<IAccommodationCommands, AccommodationCommandsService>();
			services.AddScoped<IAccommodationQueries, AccommodationQueriesService>();

			services.AddScoped<IGuestCommands, GuestCommandsService>();
			services.AddScoped<IGuestQueries, GuestQueriesService>();


			return services;
		}
	}
}
