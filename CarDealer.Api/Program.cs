﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace CarDealer.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger(); 
			try
			{
				logger.Debug("init main function");
				CreateWebHostBuilder(args).Build().Run();
			}
			catch (Exception ex)
			{
				logger.Error(ex, "Error in init");
				throw;
			}
			finally
			{
				NLog.LogManager.Shutdown();
			}
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.ConfigureLogging((hostingContext,logging) =>
				{ 
					logging.ClearProviders();
					logging.AddConsole();
					logging.AddDebug();
					logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
				})
				.UseNLog();
	}
}
