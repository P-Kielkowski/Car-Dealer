using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Interfaces.CQRS
{
	public interface ICommandHandler<TCommand> where TCommand : ICommand
	{
		Task HandleAsync(TCommand command);

	}
}
