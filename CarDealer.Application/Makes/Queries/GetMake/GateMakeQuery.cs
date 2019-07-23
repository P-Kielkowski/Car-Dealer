using CarDealer.Application.Dto;
using CarDealer.Application.Interfaces.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Makes.Queries.GetMake
{
	public class GateMakeQuery : IRequest<MakeDto>
	{
		public int Id { get; set; }

	}
}
