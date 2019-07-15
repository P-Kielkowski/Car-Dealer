﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Interfaces.CQRS
{
	public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
	{
		Task<TResult> HandleAsync(TQuery query);

	}
}
