using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Domain.Entities
{
	public class Make
	{
		public Make()
		{
			Models = new List<Model>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public IEnumerable<Model> Models { get; set; }
	}
}
