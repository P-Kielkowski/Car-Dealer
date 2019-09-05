using CarDealer.Application.Interfaces;
using CarDealer.Application.Interfaces.CQRS;
using CarDealer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealer.Application.Makes.Commands.UpdateMake
{
	public class UpdateMakeCommandHandler : IRequestHandler<UpdateMakeCommand>
	{
		private readonly ICarDealerContext context;

		public UpdateMakeCommandHandler(ICarDealerContext carDealerContext)
		{
			this.context = carDealerContext;
		}

		public async Task<Unit> Handle(UpdateMakeCommand request, CancellationToken cancellationToken)
		{
			var make = await this.context.Makes.FirstOrDefaultAsync(a => a.Id == request.Id);
			make.Name = request.Name;

			await this.context.SaveChangesAsync(cancellationToken);
			return Unit.Value;
		}

	}
}
