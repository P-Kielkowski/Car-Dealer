using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Makes.Commands.AddMake
{
	public class AddMakeCommandValidator : AbstractValidator<AddMakeCommand>
	{
		public AddMakeCommandValidator()
		{
			RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
		}
	}
}
