using CarDealer.Application.Dto;
using CarDealer.Application.Interfaces.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Makes.Queries.GetAllMakes
{
	public class GetAllMakesQuery : IQuery<List<MakeWithModelsDto>>
	{
	}
}
