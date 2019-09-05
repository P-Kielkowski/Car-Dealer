using CarDealer.Application.Features.Vehicles.Commands.AddVehicle;
using CarDealer.Application.Features.Vehicles.Queries.GetAddVehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Api.Controllers
{
	public class VehicleController : BaseController
	{
		private readonly ILogger<VehicleController> logger;

		public VehicleController(ILogger<VehicleController> logger)
		{
			this.logger = logger;
		}

		[HttpPost]
		public async Task<ActionResult<int>> CreateVehicle([FromBody] AddVehicleCommand command)
		{
			int id = await this.Mediator.Send(command);

			return Ok(id);
		}

		[HttpGet]
		public async Task<ActionResult<List<GetAllVehiclesDto>>> GetAllVehicles()
		{
			var vehicles = await this.Mediator.Send(new GetAllVehiclesQuery());

			if (vehicles == null)
			{
				return NotFound();
			}

			return Ok(vehicles);
		}


	}
}
