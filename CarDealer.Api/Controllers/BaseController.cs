using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Application.Interfaces.CQRS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
		protected readonly IDispatcher dispatcher;

		public BaseController(IDispatcher _dispatcher)
		{
			this.dispatcher = _dispatcher;
		}
	}
}