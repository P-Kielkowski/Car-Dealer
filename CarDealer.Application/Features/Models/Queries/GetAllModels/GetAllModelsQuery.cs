using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Models.Queries.GetAllModels
{
	public class GetAllModelsQuery : IRequest<List<GetAllModelsDto>>
	{
	}
}
