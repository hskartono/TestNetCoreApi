using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCoreApi.Dto
{
	public class ProvinceDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string HQAddress { get; set; }
		public List<CityDto> Cities { get; set; }
	}
}
