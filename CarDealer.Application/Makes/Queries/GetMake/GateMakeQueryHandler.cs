using AutoMapper;
using CarDealer.Application.Dto;
using CarDealer.Application.Interfaces;
using CarDealer.Application.Interfaces.CQRS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Makes.Queries.GetMake
{
	public class GateMakeQueryHandler : IQueryHandler<GateMakeQuery, MakeDto>
	{
		private readonly ICarDealerContext context;
		private readonly IMapper mapper;

		public GateMakeQueryHandler(ICarDealerContext carDealerContext, IMapper mapper)
		{
			this.context = carDealerContext;
			this.mapper = mapper;
		}

		public async Task<MakeDto> HandleAsync(GateMakeQuery query)
		{
			var make = await this.context.Makes.FirstOrDefaultAsync(a => a.Id == query.Id);

			if (make == null)
				return null;

			return mapper.Map<MakeDto>(make);
		}
	}
}

