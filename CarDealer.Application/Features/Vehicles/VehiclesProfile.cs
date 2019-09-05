using AutoMapper;
using CarDealer.Application.Features.Vehicles.Commands.AddVehicle;
using CarDealer.Application.Features.Vehicles.Queries.GetAddVehicles;
using CarDealer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Features.Vehicles
{
	public class VehiclesProfile : Profile
	{
		public VehiclesProfile()
		{
			//commands to entities
			CreateMap<AddVehicleCommand, Vehicle>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.ModelId, opt => opt.MapFrom(vc => vc.ModelId))
				.ForMember(dest => dest.ContactName, opt => opt.MapFrom(vc => vc.ContactName))
				.ForMember(dest => dest.ContantPhone, opt => opt.MapFrom(vc => vc.ContactPhone))
				.ForMember(dest => dest.LastUpdate, opt => opt.MapFrom(vc => vc.LastUpdate))
				.ForAllOtherMembers(opt => opt.Ignore());
				

			//entities to Dto's
			CreateMap<Vehicle, GetAllVehiclesDto>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(vc => vc.Id))
				.ForMember(dest => dest.Model, opt => opt.MapFrom(vc => vc.Model))
				.ForMember(dest => dest.ContactName, opt => opt.MapFrom(vc => vc.ContactName))
				.ForMember(dest => dest.ContantPhone, opt => opt.MapFrom(vc => vc.ContantPhone))
				.ForMember(dest => dest.LastUpdate, opt => opt.MapFrom(vc => vc.LastUpdate))
				.ForAllOtherMembers(opt => opt.Ignore());
			CreateMap<Model, GetAllVehiclesModelDto>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(vc => vc.Id))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(vc => vc.Name));
		}
	}
}
