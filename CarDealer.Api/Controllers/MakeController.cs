﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Application.Dto;
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
		public MakeController(ILogger<MakeController> logger ,IDispatcher dispatcher) : base(dispatcher)
		{
			this.logger = logger;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllMakes()
		{
			var makes = await this.dispatcher.HandleQueryAsync<GetAllMakesQuery, List<MakeWithModelsDto>>(new GetAllMakesQuery());
			//this.logger.LogInformation("Getting item {ID}", query.Id);

			if (makes == null)
			{
				//this.logger.LogWarning("Cannot find Make object with corresponding id: {0}", query.Id);
				return NotFound();
			}

			return Ok();
		}

		[HttpGet("{Id}")]
		public async Task<ActionResult<MakeDto>> GetMake([FromRoute] GateMakeQuery query)
		{
			var make = await this.dispatcher.HandleQueryAsync<GateMakeQuery, MakeDto>(query);
			this.logger.LogInformation("Getting item {ID}", query.Id);

			if (make == null)
			{
				this.logger.LogWarning("Cannot find Make object with corresponding id: {0}", query.Id);
				return NotFound(query);
			}

			return Ok(make);
		}

		[HttpPost]
		public async Task<ActionResult> CreateMake([FromBody] AddMakeCommand command)
		{
			await this.dispatcher.HandleCommandAsync(command);

			return Ok();
		}

		[HttpPut]
		public async Task<ActionResult> UpdateMake([FromBody] UpdateMakeCommand command)
		{
			await this.dispatcher.HandleCommandAsync(command);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteMake( int id)
		{
			await this.dispatcher.HandleCommandAsync( new DeleteMakeCommand(id) );

			return NoContent();
		}
	}
}