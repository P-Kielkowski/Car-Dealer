using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Models.Queries.GetAllModels
{
	public class GetAllModelsDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public MakeDto Make { get; set; }

	}

	public class MakeDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
