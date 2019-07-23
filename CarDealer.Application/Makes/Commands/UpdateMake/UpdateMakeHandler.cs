using CarDealer.Application.Interfaces;
using CarDealer.Application.Interfaces.CQRS;
using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Makes.Commands.UpdateMake
{
	public class UpdateMakeHandler : ICommandHandler<UpdateMakeCommand>
	{
		private readonly ICarDealerContext context;

		public UpdateMakeHandler(ICarDealerContext carDealerContext)
		{
			this.context = carDealerContext;
		}

		public async Task HandleAsync(UpdateMakeCommand command)
		{
			var make = await this.context.Makes.FirstOrDefaultAsync(a => a.Id == command.Id);
			make.Name = command.Name;

			await this.context.SaveChangesAsync();
		}
	}
}
