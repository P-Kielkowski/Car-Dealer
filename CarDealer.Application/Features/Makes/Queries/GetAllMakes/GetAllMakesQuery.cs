using CarDealer.Application.Interfaces.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Makes.Queries.GetAllMakes
{
	public class GetAllMakesQuery : IRequest<List<GetAllMakesDto>>
	{
	}
}
