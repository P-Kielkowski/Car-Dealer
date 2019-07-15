using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Interfaces.CQRS
{
	public interface IQueryDispatcher
	{
		Task<TResult> HandleQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;

	}
}
