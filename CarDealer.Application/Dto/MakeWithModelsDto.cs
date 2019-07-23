using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Dto
{
	public class MakeWithModelsDto : MakeDto
	{
		public MakeWithModelsDto()
		{
			Models = new List<ModelDto>();
		}
		public IEnumerable<ModelDto> Models { get; set; }

	}
}
