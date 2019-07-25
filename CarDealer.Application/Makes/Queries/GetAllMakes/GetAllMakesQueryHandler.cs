using AutoMapper;
using CarDealer.Application.Interfaces;
using CarDealer.Application.Interfaces.CQRS;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealer.Application.Makes.Queries.GetAllMakes
{
	public class GetAllMakesQueryHandler : IRequestHandler<GetAllMakesQuery, List<GetAllMakesDto>>
	{
		private readonly ICarDealerContext context;
		private readonly IMapper mapper;

		public GetAllMakesQueryHandler(ICarDealerContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<List<GetAllMakesDto>> Handle(GetAllMakesQuery request, CancellationToken cancellationToken)
		{
			var makes = await context.Makes.Include(a => a.Models).ToListAsync(cancellationToken);

			if (makes == null)
				return null;

			return mapper.Map<List<GetAllMakesDto>>(makes); 
		}

	}

}
