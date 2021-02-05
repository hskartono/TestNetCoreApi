using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCoreApi.Entities
{
	public class City
	{
		public City()
		{

		}

		public City(string name, string lokasiBalaiKota, Province province)
		{
			Name = name;
			LokasiBalaiKota = lokasiBalaiKota;
			if(province != null)
			{
				ProvinceId = province.Id;
				Province = province;
			}
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string LokasiBalaiKota { get; set; }
		public int ProvinceId { get; set; }
		public virtual Province Province { get; set; }
	}
}
