using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CarDealer.Api.Extensions;
using CarDealer.Application.Interfaces.CQRS;
using CarDealer.Common;
using CarDealer.Persistance;
using CarDealer.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Polly;
using AutoMapper;
using System.Reflection;
using MediatR;
using FluentValidation.AspNetCore;


namespace CarDealer.Api
{
	public class Startup
	{
		private readonly ILoggerFactory loggerFactory;

		public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
		{
			Configuration = configuration;
			this.loggerFactory = loggerFactory;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
				.AddFluentValidation(rs => rs.RegisterValidatorsFromAssemblyContaining<ICarDealerContext>());

			services.AddQueryOrCommand(typeof(ICommandHandler<>));
			services.AddQueryOrCommand(typeof(IQueryHandler<,>));
			services.AddScoped<IDispatcher, Dispatcher>();

			services.AddDbContext<ICarDealerContext, CarDealerContext>(
				opt => opt.UseSqlServer(Configuration.GetConnectionString("CarDealerDb"),
				mg => mg.MigrationsAssembly("CarDealer.Persistance")
			));

			services.AddMediatR(Assembly.GetAssembly(typeof(ICarDealerContext)));
			services.AddAutoMapper(Assembly.GetAssembly(typeof(ICarDealerContext)));
			services.AddPollyHttpClient(loggerFactory, "RetryClient", "https://sampleUrl.com/", 7);
			services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "CarDealer API", Version = "V1" }));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseExceptionHandler(loggerFactory);
			app.UseHttpsRedirection();
			app.UseMvc();
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1"));

		}
	}
}
