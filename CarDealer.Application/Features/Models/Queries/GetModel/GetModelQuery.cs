using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Models.Queries.GetModel
{
	public class GetModelQuery : IRequest<GetModelDto>
	{
		public int Id { get; set; }
	}
}
