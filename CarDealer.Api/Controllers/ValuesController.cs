using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarDealer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly ILogger<ValuesController> logger;
		private readonly IHttpClientFactory httpClientFactory;

		public ValuesController( ILogger<ValuesController> logger, IHttpClientFactory httpClientFactory )
		{
			this.logger = logger;
			this.httpClientFactory = httpClientFactory;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			this.logger.LogInformation("Getting all items");

			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public async Task<ActionResult<string>> Get(int id)
		{

			//get from httpclient configured in startup 
			var client = httpClientFactory.CreateClient("PolyClient");
			var result = await client.GetAsync("https://httpbin.org/get");


			this.logger.LogInformation("Getting item {ID}", id);

			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
