using CarDealer.Application.Interfaces;
using CarDealer.Application.Interfaces.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Makes.Commands.DeleteMake
{
	public class DeleteMakeCommandHandler : ICommandHandler<DeleteMakeCommand>
	{
		private readonly ICarDealerContext context;

		public DeleteMakeCommandHandler(ICarDealerContext carDealerContext)
		{
			this.context = carDealerContext;
		}

		public async Task HandleAsync(DeleteMakeCommand command)
		{
			var toRemove = this.context.Makes.FirstOrDefault(a => a.Id == command.Id);

			if (toRemove != null)
				this.context.Makes.Remove(toRemove);

			await this.context.SaveChangesAsync();

		}
	}
}
