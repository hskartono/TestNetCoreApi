using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCoreApi.Dto
{
	public class CityDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LokasiBalaiKota { get; set; }
		public int ProvinceId { get; set; }
		public string ProvinceName { get; set; }

	}
}
