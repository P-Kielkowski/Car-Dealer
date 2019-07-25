using AutoMapper;
using CarDealer.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealer.Application.Models.Queries.GetAllModels
{
	class GetAllModelsQueryHandler : IRequestHandler<GetAllModelsQuery, List<GetAllModelsDto>>
	{
		private readonly ICarDealerContext context;
		private readonly IMapper mapper;

		public GetAllModelsQueryHandler( ICarDealerContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<List<GetAllModelsDto>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
		{
			var models = await this.context.Models.OrderBy( a => a.Name).Include( a=> a.Make ).ToListAsync(cancellationToken);

			if (models == null)
				return null;

			return mapper.Map<List<GetAllModelsDto>>(models);
		}
	}
}
