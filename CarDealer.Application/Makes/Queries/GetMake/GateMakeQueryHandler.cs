using CarDealer.Application.Interfaces;
using CarDealer.Application.Interfaces.CQRS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Makes.Queries.GetMake
{
	public class GateMakeQueryHandler : IQueryHandler<GateMakeQuery, GateMakeDto>
	{
		private readonly ICarDealerContext context;

		public GateMakeQueryHandler(ICarDealerContext carDealerContext)
		{
			this.context = carDealerContext;

		}

		public async Task<GateMakeDto> HandleAsync(GateMakeQuery query)
		{
			var make = await this.context.Makes.FirstOrDefaultAsync(a => a.Id == query.Id);

			if (make == null)
				return null;

			var makeDto = new GateMakeDto
			{
				Id = make.Id,
				Name = make.Name
			};

			return makeDto;
		}
	}
}

