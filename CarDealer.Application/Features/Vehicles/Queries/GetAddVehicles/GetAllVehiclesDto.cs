using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Features.Vehicles.Queries.GetAddVehicles
{
	public class GetAllVehiclesDto
	{
		public int Id { get; set; }

		public GetAllVehiclesModelDto Model { get; set; }

		public string ContactName { get; set; }

		public string ContantPhone { get; set; }

		public DateTime LastUpdate { get; set; }

	}

	public class GetAllVehiclesModelDto
	{
		public int  Id { get; set; }
		public string Name { get; set; }
	}
}
