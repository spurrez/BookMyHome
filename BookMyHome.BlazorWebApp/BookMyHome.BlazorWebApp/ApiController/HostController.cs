using BookMyHome.Application.Services.GuestService.Interfaces;
using BookMyHome.Application.Services.HostService.Interfaces;
using BookMyHome.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Host = BookMyHome.Domain.Entities.Host;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyHome.BlazorWebApp.Server.ApiController
{
	[Route("api/[controller]")]
	[ApiController]
	public class HostController : ControllerBase
	{
		private readonly IHostQueries _hostQueries;
		private readonly IHostCommands _hostCommands;
        public HostController(IHostQueries hostQueries, IHostCommands hostCommands)
        {
            _hostQueries = hostQueries;
			_hostCommands = hostCommands;
        }
        [HttpGet]
		public async Task<IActionResult> Get()
		{
			var hosts = await _hostQueries.GetAllHosts();
			if (hosts == null || !hosts.Any())
				return NotFound("Guests are empty");
			return Ok(hosts);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var host = await _hostQueries.GetHostById(id);
			if (host == null)
				return NotFound("Did not find the accommodation");
			return Ok(host);
		}

		[HttpPost]
		public async Task<IActionResult> Post(Host host)
		{
			var createdHost = await _hostCommands.CreateHost(host);
			if (createdHost == null)
				return NotFound("Failed to create");
			return Ok(createdHost);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Host host)
		{
			var updatedHost = await _hostCommands.UpdateHost(id, host);
			if (updatedHost == null)
				return NotFound("Failed to update");
			return Ok(updatedHost);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			bool deletedHost = await _hostCommands.DeleteHost(id);
			if (!deletedHost)
				return NotFound("Failed to delete");
			return NoContent();
		}
	}
}
