using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Models.Queries.GetModel
{
	public class GetModelQueryValidator : AbstractValidator<GetModelQuery>
	{
		public GetModelQueryValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
		}
	}
}
