using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Infrastructure.Persistence.Interfaces;
using BookMyHome.Infrastructure.Persistence.Repositories;
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
			return services;
		}
	}
}
