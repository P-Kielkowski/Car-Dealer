using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Api.Extensions
{
	public static class IApplicationBuilderExtensions
	{

		public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
		{
			app.UseExceptionHandler(appError => appError.Run(async context =>
			{
				context.Response.ContentType = "application/json";

				var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
				if (contextFeature != null)
				{
					loggerFactory.CreateLogger("Global").LogError($"Something went wrong: {contextFeature.Error}");

					await context.Response.WriteAsync("Global error Handled. Code: " + context.Response.StatusCode + " |Error: " + contextFeature.Error.Message);
				}
			}));
			return app;
		}
	}
}
