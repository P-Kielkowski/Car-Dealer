using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Domain.Entities
{
	public class Model
	{
		public Model()
		{
			Vehicles = new List<Vehicle>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public int MakeId { get; set; }

		public Make Make { get; set; }

		public IEnumerable<Vehicle> Vehicles { get; set; }
	}
}
