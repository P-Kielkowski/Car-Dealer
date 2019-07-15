using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Domain.Entities
{
	public class VehicleFeature
	{
		public int VehicleId { get; set; }
		public Vehicle Vehicle { get; set; }

		public int FeaturesId { get; set; }
		public Feature Features { get; set; }
	}
}
