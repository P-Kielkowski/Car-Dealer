using AutoMapper;
using CarDealer.Application.Interfaces;
using CarDealer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealer.Application.Features.Vehicles.Queries.GetAddVehicles
{
	public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, List<GetAllVehiclesDto>>
	{
		private readonly ICarDealerContext context;
		private readonly IMapper mapper;

		public GetAllVehiclesQueryHandler(ICarDealerContext carDealerContext, IMapper mapper)
		{
			this.context = carDealerContext;
			this.mapper = mapper;
		}
		public async Task<List<GetAllVehiclesDto>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
		{
			var vehicles = await this.context.Vehicles.Include(a => a.Model)
				.ThenInclude(b => b.Make).ToListAsync();

			return this.mapper.Map<List<GetAllVehiclesDto>>(vehicles);
		}
	}
}
