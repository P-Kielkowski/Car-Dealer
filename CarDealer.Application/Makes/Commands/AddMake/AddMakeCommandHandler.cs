using CarDealer.Application.Interfaces;
using CarDealer.Application.Interfaces.CQRS;
using CarDealer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Makes.Commands.AddMake
{
	public class AddMakeCommandHandler : ICommandHandler<AddMakeCommand>
	{
		private readonly ICarDealerContext context;

		public AddMakeCommandHandler(ICarDealerContext carDealerContext)
		{
			this.context = carDealerContext;
		}

		public async Task HandleAsync(AddMakeCommand command)
		{
			var make = new Make
			{
				Name = command.Name
			};

			await this.context.Makes.AddAsync(make);

			await this.context.SaveChangesAsync();

		}
	}
}
