using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Domain.Entities
{
	public class Feature
	{
		public Feature()
		{
			VehicleFeatures = new List<VehicleFeature>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public IEnumerable<VehicleFeature> VehicleFeatures { get; set; }
	}
}
