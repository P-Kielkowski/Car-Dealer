using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Makes.Commands.DeleteMake
{
	public class DeleteMakeCommandValidator : AbstractValidator<DeleteMakeCommand>
	{
		public DeleteMakeCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty(); 
		}
	}
}
