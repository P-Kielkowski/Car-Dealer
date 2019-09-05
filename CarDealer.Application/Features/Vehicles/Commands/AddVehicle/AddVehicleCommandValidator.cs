using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Features.Vehicles.Commands.AddVehicle
{
	public class AddVehicleCommandValidator : AbstractValidator<AddVehicleCommand>
	{
		public AddVehicleCommandValidator()
		{
			RuleFor(x => x.ModelId).NotEmpty();
			RuleFor(x => x.ContactName).NotEmpty().MinimumLength(2);
			RuleFor(x => x.ContactPhone).NotEmpty().Matches("^([1-9]{1})([0-9]{2})-[0-9]{3}-[0-9]{3}$");
			RuleFor(x => x.LastUpdate).NotEmpty().LessThanOrEqualTo(DateTime.Now);
		}
	}
}
