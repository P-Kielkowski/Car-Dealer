using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Application.Models.Commands.AddModel;
using CarDealer.Application.Models.Queries.GetAllModels;
using CarDealer.Application.Models.Queries.GetModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarDealer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : BaseController
    {
		private readonly ILogger<MakeController> logger;
		public ModelController(ILogger<MakeController> logger)
		{
			this.logger = logger;
		}


		[HttpGet]
		public async Task<ActionResult<List<GetAllModelsDto>>> GetAllModels()
		{
			var models = await this.Mediator.Send(new GetAllModelsQuery());

			if (models == null)
			{
				return NotFound();
			}

			return Ok(models);
		}

		[HttpGet("{Id}")]
		public async Task<ActionResult<GetModelDto>> GetMake([FromRoute] GetModelQuery query)
		{
			var model = await this.Mediator.Send(query);
			this.logger.LogInformation("Getting item {ID}", query.Id);

			if (model == null)
			{
				this.logger.LogWarning("Cannot find Make object with corresponding id: {0}", query.Id);
				return NotFound(query);
			}

			return Ok(model);
		}

		[HttpPost]
		public async Task<ActionResult<int>> CreateMake([FromBody] AddModelCommand command)
		{
			int id = await this.Mediator.Send(command);

			return Ok(id);
		}

	}
}