using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Application.Interfaces.CQRS;
using CarDealer.Application.Makes.Commands.AddMake;
using CarDealer.Application.Makes.Commands.DeleteMake;
using CarDealer.Application.Makes.Commands.UpdateMake;
using CarDealer.Application.Makes.Queries.GetAllMakes;
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
		public MakeController(ILogger<MakeController> logger )
		{
			this.logger = logger;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetAllMakesDto>>> GetAllMakes()
		{
			var makes = await this.Mediator.Send(new GetAllMakesQuery());

			if (makes == null)
			{
				return NotFound();
			}

			return Ok(makes);
		}

		[HttpGet("{Id}")]
		public async Task<ActionResult<GetMakeDto>> GetMake([FromRoute] GetMakeQuery query)
		{
			var make = await this.Mediator.Send(query);
			this.logger.LogInformation("Getting item {ID}", query.Id);

			if (make == null)
			{
				this.logger.LogWarning("Cannot find Make object with corresponding id: {0}", query.Id);
				return NotFound(query);
			}

			return Ok(make);
		}

		[HttpPost]
		public async Task<ActionResult<int>> CreateMake([FromBody] AddMakeCommand command)
		{
			int id = await this.Mediator.Send(command);

			return Ok(id);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateMake([FromBody] UpdateMakeCommand command)
		{
			await this.Mediator.Send(command);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteMake( int id)
		{
			await this.Mediator.Send(new DeleteMakeCommand(id));

			return NoContent();
		}
	}
}