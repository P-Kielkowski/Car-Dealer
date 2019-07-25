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


namespace CarDealer.Application.Models.Queries.GetModel
{
	class GetModelQueryHandler : IRequestHandler<GetModelQuery, GetModelDto>
	{
		private readonly ICarDealerContext context;
		private readonly IMapper mapper;

		public GetModelQueryHandler(ICarDealerContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<GetModelDto> Handle(GetModelQuery request, CancellationToken cancellationToken)
		{
			var model = await this.context.Models.Include(a => a.Make).FirstOrDefaultAsync(a => a.Id == request.Id);

			if (model == null)
				return null;

			return mapper.Map<GetModelDto>(model);
		}
	}
}
