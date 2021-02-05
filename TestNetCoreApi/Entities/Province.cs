using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCoreApi.Entities
{
	public class Province
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string HQAddress { get; set; }

		private List<City> _cities = new List<City>();
		public IReadOnlyList<City> Cities => _cities;

		public void AddCity(string name, string lokasiBalaikota)
		{
			var city = new City(name, lokasiBalaikota, this);
			_cities.Add(city);
		}

		public void AddOrReplaceCity(City city)
		{
			City selected = null;
			int index = 0;
			foreach(var item in _cities)
			{
				if(item.Id == city.Id)
				{
					selected = item;
					break;
				}
			}

			if(selected == null)
			{
				_cities.Add(city);
			} else
			{
				_cities[index] = city;
			}
		}

		public void RemoveCity(City city)
		{
			_cities.Remove(city);
		}

		public void ClearCity()
		{
			_cities.Clear();
		}
	}
}
