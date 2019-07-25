using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Models.Commands.AddModel
{
	public class AddModelCommandValidator : AbstractValidator<AddModelCommand>
	{
		public AddModelCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.MakeId).NotEmpty();
			RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
		}
	}
}
