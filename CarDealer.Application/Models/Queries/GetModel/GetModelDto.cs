using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Models.Queries.GetModel
{
	public class GetModelDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public GetModelMakeDto Make { get; set; }

	}
	public class GetModelMakeDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

}
