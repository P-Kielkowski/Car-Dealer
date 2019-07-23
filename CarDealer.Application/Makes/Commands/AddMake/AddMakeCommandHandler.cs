using CarDealer.Application.Interfaces;
using CarDealer.Application.Interfaces.CQRS;
using CarDealer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealer.Application.Makes.Commands.AddMake
{
	public class AddMakeCommandHandler : IRequestHandler<AddMakeCommand,int>
	{
		private readonly ICarDealerContext context;

		public AddMakeCommandHandler(ICarDealerContext carDealerContext)
		{
			this.context = carDealerContext;
		}

		public async Task<int> Handle(AddMakeCommand request, CancellationToken cancellationToken)
		{
			var make = new Make
			{
				Name = request.Name
			};

			this.context.Makes.Add(make);

			await this.context.SaveChangesAsync(cancellationToken);
			return make.Id;
		}


	}
}
