using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Makes.Commands.UpdateMake
{
	public class UpdateMakeCommandValidator : AbstractValidator<UpdateMakeCommand>
	{
		public UpdateMakeCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
		}
	}
}
