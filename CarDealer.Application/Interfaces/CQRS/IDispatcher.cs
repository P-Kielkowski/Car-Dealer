using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Interfaces.CQRS
{
	public interface IDispatcher : ICommandDispatcher , IQueryDispatcher
	{
	}
}
