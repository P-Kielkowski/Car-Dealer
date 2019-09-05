using CarDealer.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarDealer.Domain.Entities;
using AutoMapper;

namespace CarDealer.Application.Features.Vehicles.Commands.AddVehicle
{
	public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, int>
	{
		private readonly ICarDealerContext context;
		private readonly IMapper mapper;

		public AddVehicleCommandHandler(ICarDealerContext carDealerContext, IMapper mapper)
		{
			this.context = carDealerContext;
			this.mapper = mapper;
		}


		public async Task<int> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
		{
			this.context.Vehicles.Add(mapper.Map<Vehicle>(request));

			return await this.context.SaveChangesAsync(cancellationToken);
		}
	}
}
