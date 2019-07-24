using AutoMapper;
using CarDealer.Application.Makes.Queries.GetAllMakes;
using CarDealer.Application.Makes.Queries.GetMake;
using CarDealer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Mappings
{
	class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Make, GetMakeDto>();
			CreateMap<Model, ModelDto>();
			CreateMap<Make, GetAllMakesDto>();

		}

	}
}
