using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Features.Vehicles.Queries.GetAddVehicles
{
	public class GetAllVehiclesQuery : IRequest<List<GetAllVehiclesDto>>
	{
	}
}
