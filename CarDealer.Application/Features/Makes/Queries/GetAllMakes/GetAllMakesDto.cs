using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Makes.Queries.GetAllMakes
{
	public class GetAllMakesDto
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public GetAllMakesDto()
		{
			Models = new List<ModelDto>();
		}
		public IEnumerable<ModelDto> Models { get; set; }
	}

	public class ModelDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}


