using CarDealer.Application.Interfaces.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealer.Common
{
	public class Dispatcher : IDispatcher
	{
		private readonly IServiceProvider serviceProvider;

		public Dispatcher(IServiceProvider provider)
		{
			this.serviceProvider = provider;
		}

		public async Task<TResult> HandleQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
		{
			var handler = serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();
			return await handler.HandleAsync(query);
		}

		public async Task HandleCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
		{
			var handler = serviceProvider.GetService<ICommandHandler<TCommand>>();

			await handler.HandleAsync(command);
		}
	}
}
