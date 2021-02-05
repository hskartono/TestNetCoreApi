using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNetCoreApi.Dto;
using TestNetCoreApi.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace TestNetCoreApi.Controllers
{
	[ApiController]
	[Route("/api/v1/[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;
		private readonly ITransientService _transientService1;
		private readonly ITransientService _transientService2;
		private readonly IScopedService _scopedService1;
		private readonly IScopedService _scopedService2;
		private readonly ISingletonService _singletonService1;
		private readonly ISingletonService _singletonService2;
		private readonly IMapper _mapper;
		private readonly AppDbContext _context;

		public WeatherForecastController(
			ILogger<WeatherForecastController> logger,
			ITransientService transientService1,
			ITransientService transientService2,
			IScopedService scopedService1,
			IScopedService scopedService2,
			ISingletonService singletonService1,
			ISingletonService singletonService2,
			IMapper mapper,
			AppDbContext context
			)
		{
			_logger = logger;
			_mapper = mapper;
			_context = context;

			_transientService1 = transientService1;
			_transientService2 = transientService2;
			_scopedService1 = scopedService1;
			_scopedService2 = scopedService2;
			_singletonService1 = singletonService1;
			_singletonService2 = singletonService2;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var result = new Dictionary<string, string>()
			{
				{"Transient 1", _transientService1.operationId().ToString() },
				{"Transient 2", _transientService2.operationId().ToString() },
				{"Scoped 1", _scopedService1.operationId().ToString() },
				{"Scoped 2", _scopedService2.operationId().ToString() },
				{"Singleton 1", _singletonService1.operationId().ToString() },
				{"Singleton 2", _singletonService2.operationId().ToString() }
			};

			return Ok(result);
		}

		// get list
		[HttpGet]
		[Route("City")]
		public IActionResult GetCityList()
		{
			var p = _context.Provinces.Where(e => e.Id == 1).SingleOrDefault();
			p.Name = "Berubah";
			_context.SaveChanges();

			var provincesdto = _context.Provinces
				.Include(p => p.Cities)
				.Select(_mapper.Map<ProvinceDto>)
				.ToList();

			return Ok(provincesdto);

		}

		[HttpGet]
		[Route("City/{id}")]
		public IActionResult GetCityList(int id)
		{
			return null;
		}

		[HttpPost]
		public IActionResult Create([FromBody] ProvinceDto param)
		{
			return null;
		}

		[HttpPut]
		[Route("{id}")]
		public IActionResult Update([FromBody] ProvinceDto param, int id)
		{
			return null;
		}

		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete(int id)
		{
			return null;
		}

		//[HttpPost]	// biasanya untuk create
		//[HttpPut]		// untuk update
		//[HttpDelete]	// untuk hapus data

		//Master Data Warehouse[CRUD]
		//id, name, description

		/*
		 Master Data Item [CRUD]
id, name

Transaction 
GoodIssue [CRUD]
id, transactionNo, transactionDate, warehouseId

GoodIssueDetail
id, goodIssueId, itemId, Qty

		 */
	}
}
