using CarDealer.Application.Interfaces;
using CarDealer.Application.Interfaces.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealer.Application.Makes.Commands.DeleteMake
{
	public class DeleteMakeCommandHandler : IRequestHandler<DeleteMakeCommand>
	{
		private readonly ICarDealerContext context;

		public DeleteMakeCommandHandler(ICarDealerContext carDealerContext)
		{
			this.context = carDealerContext;
		}

		public async Task<Unit> Handle(DeleteMakeCommand request, CancellationToken cancellationToken)
		{
			var toRemove = this.context.Makes.FirstOrDefault(a => a.Id == request.Id);

			if (toRemove != null)
				this.context.Makes.Remove(toRemove);

			await this.context.SaveChangesAsync(cancellationToken);
			return Unit.Value;
		}

	}
}
