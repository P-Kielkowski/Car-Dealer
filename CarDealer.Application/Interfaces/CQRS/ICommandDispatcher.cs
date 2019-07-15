using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Interfaces.CQRS
{
	public interface ICommandDispatcher
	{
		Task HandleCommandAsync<TCommand>(TCommand command) where TCommand : ICommand;

	}
}
