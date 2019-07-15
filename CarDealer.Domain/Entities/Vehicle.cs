using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Domain.Entities
{
	public class Vehicle
	{
		public Vehicle()
		{
			VehicleFeatures = new List<VehicleFeature>();
		}
		public int Id { get; set; }

		public int ModelId { get; set; }

		public Model Model { get; set; }

		public string ContactName { get; set; }

		public string ContantPhone { get; set; }

		public DateTime LastUpdate { get; set; }

		public IEnumerable<VehicleFeature> VehicleFeatures { get; set; }
	}
}
