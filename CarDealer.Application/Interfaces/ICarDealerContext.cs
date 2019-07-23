using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealer.Application.Interfaces
{
	public interface ICarDealerContext
	{
		DbSet<Make> Makes { get; set; }

		DbSet<Model> Models { get; set; }

		DbSet<Feature> Features { get; set; }

		DbSet<VehicleFeature> VehicleFeatures { get; set; }

		DbSet<User> Users { get; set; }

		DbSet<Vehicle> Vehicles { get; set; }

		int SaveChanges();

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);


	}
}
