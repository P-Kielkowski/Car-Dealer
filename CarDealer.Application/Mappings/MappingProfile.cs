using AutoMapper;
using CarDealer.Application.Makes.Queries.GetAllMakes;
using CarDealer.Application.Makes.Queries.GetMake;
using CarDealer.Application.Models.Queries.GetAllModels;
using CarDealer.Application.Models.Queries.GetModel;
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
			CreateMap<Make, GetAllMakesDto>();
			CreateMap<Make, MakeDto>();
			CreateMap<Make, GetModelMakeDto>();
			CreateMap<Model, ModelDto>();
			CreateMap<Model, GetAllModelsDto>();
			CreateMap<Model, GetModelDto>();
			

		}

	}
}
