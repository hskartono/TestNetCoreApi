using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNetCoreApi.Configuration;
using TestNetCoreApi.Entities;

namespace TestNetCoreApi
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions opt) : base(opt) { }

		public DbSet<Province> Provinces { get; set; }
		public DbSet<City> Cities { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
			modelBuilder.ApplyConfiguration(new CityConfiguration());
		}
	}
}
