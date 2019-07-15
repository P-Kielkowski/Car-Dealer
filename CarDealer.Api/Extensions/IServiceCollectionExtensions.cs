using CarDealer.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Api.Extensions
{
	public static class IServiceCollectionExtensions
	{

		public static IServiceCollection AddQueryOrCommand(this IServiceCollection services, Type handlerInterface)
		{
			var handlers = typeof(ICarDealerContext).Assembly.GetTypes()
				.Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface)
			   );

			foreach (var handler in handlers)
			{
				var item = handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface);
				services.AddScoped(item, handler);
			}
			return services;
		}
	}
}
