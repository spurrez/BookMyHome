using BookMyHome.Application;
using BookMyHome.BlazorWebApp.Client.Interfaces;
using BookMyHome.BlazorWebApp.Client.Services;
using BookMyHome.BlazorWebApp.Server.Components;
using BookMyHome.Infrastructure;
using BookMyHome.Infrastructure.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookMyHome.BlazorWebApp.Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// for enabling swagger
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddInfrastructure();
			builder.Services.AddApplication();
			builder.Services.AddClientServices("https://localhost:7257"); // not sure if good practice to have direct link here but oh well


			builder.Services.AddDbContext<EntityFrameworkDBContext>(options =>
			options.UseSqlServer(
				builder.Configuration.GetConnectionString("DefaultConnection"),
				b => b.MigrationsAssembly("BookMyHome.BlazorWebApp.Server")
			));

			builder.Services.AddQuickGridEntityFrameworkAdapter();

			builder.Services.AddDatabaseDeveloperPageExceptionFilter();


			builder.Services.AddControllers();

			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents()
				.AddInteractiveWebAssemblyComponents();

			var app = builder.Build();


			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseWebAssemblyDebugging();
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
    app.UseMigrationsEndPoint();
				app.UseMigrationsEndPoint();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseAntiforgery();

			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode()
				.AddInteractiveWebAssemblyRenderMode()
				.AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

			app.MapControllers();

			app.Run();
		}
	}
}
