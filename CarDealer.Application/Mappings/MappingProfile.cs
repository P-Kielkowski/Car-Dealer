using AutoMapper;
using CarDealer.Application.Dto;
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
			CreateMap<Make, MakeDto>();
			CreateMap<Model, ModelDto>();
			CreateMap<Make, MakeWithModelsDto>();

			////DAL to VM
			//CreateMap<VehiclePhoto, VehiclePhotoViewModel>();
			//CreateMap(typeof(QueryResult<>), typeof(QueryResultViewModel<>));
			//CreateMap<Makes, MakesViewModel>();
			//CreateMap<Contracts.Models.Models, KeyValuePairViewModel>();
			//CreateMap<Vehicle, VehicleViewModel>()
			//	.ForMember(a => a.Model, opt => opt.MapFrom(v => new KeyValuePairViewModel { Id = v.Model.Id, Name = v.Model.Name }))
			//	.ForMember(a => a.Make, opt => opt.MapFrom(v => new KeyValuePairViewModel { Id = v.Model.Makes.Id, Name = v.Model.Makes.Name }))
			//	.ForMember(a => a.Features, opt => opt.MapFrom(v => v.VehicleFeature.Select(vf => new KeyValuePairViewModel { Id = vf.Features.Id, Name = vf.Features.Name })));

			////VM to DAL

			////CreateMap<VehiclePhotosViewModel, VehiclePhoto>();

			//CreateMap<SaveVehicleViewModel, Vehicle>()
			//	.ForMember(a => a.ModelsId, opt => opt.MapFrom(vm => vm.ModelsId))
			//	.ForMember(a => a.ContactName, opt => opt.MapFrom(vm => vm.ContactName))
			//	.ForMember(a => a.ContantPhone, opt => opt.MapFrom(vm => vm.ContantPhone))
			//	.ForMember(a => a.VehicleFeature, opt => opt.Ignore())
			//	.AfterMap((src, desc) =>
			//	{
			//		List<VehicleFeature> featuresToUpdate = new List<VehicleFeature>();
			//		/// existing item
			//		foreach (var feature in src.VehicleFeature)
			//		{
			//			if (!desc.VehicleFeature.Any(a => a.FeaturesId == feature))
			//				featuresToUpdate.Add(new VehicleFeature { FeaturesId = feature });
			//		}
			//		//new item - delete old
			//		foreach (var ftr in desc.VehicleFeature)
			//		{
			//			if (src.VehicleFeature.Contains(ftr.FeaturesId))
			//				featuresToUpdate.Add(new VehicleFeature { FeaturesId = ftr.FeaturesId });
			//		}
			//		desc.VehicleFeature = featuresToUpdate;
			//	});

		}

	}
}
