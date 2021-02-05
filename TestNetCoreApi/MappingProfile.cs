using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestNetCoreApi.Dto;
using TestNetCoreApi.Entities;

namespace TestNetCoreApi
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<City, CityDto>()
				.ForMember(dto=>dto.ProvinceName, opt=>opt.MapFrom(e=>e.Province.Name))
				.ReverseMap();

			CreateMap<Province, ProvinceDto>().ReverseMap();
		}
	}
}
