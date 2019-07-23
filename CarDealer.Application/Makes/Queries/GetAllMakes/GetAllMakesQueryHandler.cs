using AutoMapper;
using CarDealer.Application.Dto;
using CarDealer.Application.Interfaces;
using CarDealer.Application.Interfaces.CQRS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Makes.Queries.GetAllMakes
{
	public class GetAllMakesQueryHandler : IQueryHandler<GetAllMakesQuery, List<MakeWithModelsDto>>
	{
		private readonly ICarDealerContext context;
		private readonly IMapper mapper;

		public GetAllMakesQueryHandler(ICarDealerContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
		public async Task<List<MakeWithModelsDto>> HandleAsync(GetAllMakesQuery query)
		{
			var makes = await context.Makes.Include(a => a.Models).ToListAsync();

			var makesDto = mapper.Map <List<MakeWithModelsDto>>(makes);

			return makesDto;
		}
	}

}
