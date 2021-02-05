using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNetCoreApi.Entities;

namespace TestNetCoreApi.Configuration
{
	public class CityConfiguration : IEntityTypeConfiguration<City>
	{
		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).UseIdentityColumn();

			builder
				.HasOne(e => e.Province)
				.WithMany(d => d.Cities)
				.HasForeignKey(e => e.ProvinceId);
		}
	}
}
