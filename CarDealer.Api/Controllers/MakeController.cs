using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Application.Interfaces.CQRS;
using CarDealer.Application.Makes.Commands.AddMake;
using CarDealer.Application.Makes.Commands.DeleteMake;
using CarDealer.Application.Makes.Queries.GetMake;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarDealer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeController : BaseController
    {
		private readonly ILogger<MakeController> logger;
		public MakeController(ILogger<MakeController> logger ,IDispatcher dispatcher) : base(dispatcher)
		{
			this.logger = logger;
		}

		[HttpGet("{Id}")]
		public async Task<ActionResult<GateMakeDto>> GetMake([FromRoute] GateMakeQuery query)
		{
			var make = await this.dispatcher.HandleQueryAsync<GateMakeQuery, GateMakeDto>(query);
			this.logger.LogInformation("Getting item {ID}", query.Id);

			if (make == null)
			{
				this.logger.LogWarning("Cannot find Make object with corresponding id: {0}", query.Id);
				return NotFound();
			}

			return Ok(make);
		}

		[HttpPost]
		public async Task<ActionResult> Create([FromBody] AddMakeCommand command)
		{
			await this.dispatcher.HandleCommandAsync(command);

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete( int id)
		{
			await this.dispatcher.HandleCommandAsync( new DeleteMakeCommand(id) );

			return Ok();
		}
	}
}