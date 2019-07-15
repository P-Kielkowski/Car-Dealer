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

namespace CarDealer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeController : BaseController
    {
		public MakeController(IDispatcher dispatcher) : base(dispatcher) { }

		[HttpGet("{Id}")]
		public async Task<ActionResult<GateMakeDto>> GetMake([FromRoute] GateMakeQuery query)
		{
			var make = await this.dispatcher.HandleQueryAsync<GateMakeQuery, GateMakeDto>(query);

			if (make == null)
				return NotFound();

			return Ok(make);
		}

		[HttpPost]
		public async Task<ActionResult> Create([FromBody] AddMakeCommand command)
		{
			await this.dispatcher.HandleCommandAsync(command);

			return Ok();
		}

		[HttpDelete("{Id}")]
		public async Task<ActionResult> Delete([FromRoute] DeleteMakeCommand command)
		{
			await this.dispatcher.HandleCommandAsync(command);

			return Ok();
		}
	}
}