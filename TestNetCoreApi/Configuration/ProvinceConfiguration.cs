using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNetCoreApi.Entities;

namespace TestNetCoreApi.Configuration
{
	public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
	{
		public void Configure(EntityTypeBuilder<Province> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).UseIdentityColumn();

			builder
				.HasMany(e => e.Cities)
				.WithOne(d => d.Province)
				.HasForeignKey(d => d.ProvinceId);
		}
	}
}
