using CarDealer.Application.Interfaces;
using CarDealer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealer.Application.Models.Commands.AddModel
{
	public class AddModelCommandHandler : IRequestHandler<AddModelCommand,int>
	{
		private readonly ICarDealerContext context;

		public AddModelCommandHandler(ICarDealerContext context)
		{
			this.context = context;
		}

		public async Task<int> Handle(AddModelCommand request, CancellationToken cancellationToken)
		{
			var model = new Model
			{
				Name = request.Name,
				MakeId = request.MakeId
			};

			this.context.Models.Add(model);

			await this.context.SaveChangesAsync(cancellationToken);
			return model.Id;
		}
	}
}
