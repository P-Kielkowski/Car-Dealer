using CarDealer.Application.Interfaces;
using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Persistance
{
	public class CarDealerContext : DbContext, ICarDealerContext
	{
		public CarDealerContext(DbContextOptions<CarDealerContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<VehicleFeature>().HasKey(key => new { key.FeaturesId, key.VehicleId });
		}

		public async Task<int> SaveChangesAsync()
		{
			return await base.SaveChangesAsync();
		}

		public DbSet<Make> Makes { get; set; }

		public DbSet<Model> Models { get; set; }

		public DbSet<Feature> Features { get; set; }

		public DbSet<VehicleFeature> VehicleFeatures { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<Vehicle> Vehicles { get; set; }
	}
}
