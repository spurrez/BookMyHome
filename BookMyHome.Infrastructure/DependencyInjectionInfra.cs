using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Interfaces.UnitOfWork;
using BookMyHome.Infrastructure.EntityFrameWork;
using BookMyHome.Infrastructure.Persistence.Repositories;
using BookMyHome.Infrastructure.Persistence.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Infrastructure
{
    public static class DependencyInjectionInfra
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddScoped<IBookingRepository, BookingRepository>();
			services.AddScoped<IHostRepository, HostRepository>();
			services.AddScoped<IAccommodationRepository, AccommodationRepository>();
			services.AddScoped<IGuestRepository, GuestRepository>();


	
			services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
		}
	}
}
