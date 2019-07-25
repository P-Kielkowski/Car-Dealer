using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Makes.Queries.GetMake
{
	public class GetMakeQueryValidator : AbstractValidator<GetMakeQuery>
	{
		public GetMakeQueryValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
		}
	}
}
