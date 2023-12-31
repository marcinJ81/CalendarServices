﻿using AutoMapper;
using CalendarServices.Model;
using CalendarServices.ModelDTO;
using CalendarServices.Services.Command;
using CalendarServices.Services.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalendarServices.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HairDresserServicesController : ControllerBase
	{
		private readonly IMapper mapper;

		private QueryHairDresserServices QueryService { get; set; }
		private CommandHairDresserServices CommandService { get; set; }

		public HairDresserServicesController(QueryHairDresserServices queryHairDresserServices, CommandHairDresserServices commandHairDresserServices , IMapper mapper)
		{
			QueryService = queryHairDresserServices;
			CommandService = commandHairDresserServices;
			this.mapper = mapper;
		}
		// GET: api/<HairDresserServicesController>
		[HttpGet]
		public ActionResult<IEnumerable<HairDresserServiceDto>> GetAllServices()
		{
			var result = mapper.Map<List<HairDresserServiceDto>>(QueryService.GetServices());
			return Ok(result);
		}

		// GET api/<HairDresserServicesController>/5
		[HttpGet("{id}")]
		public ActionResult<HairDresserServiceDto> GetSpecificService(int id)
		{
			var service = mapper.Map<HairDresserServiceDto>(QueryService.GetService(id));
			if (service == null)
			{
				return NotFound();
			}
			return Ok(service);
		}

		[HttpGet("typeServices")]
		public ActionResult<IEnumerable<TypeService>> GetTypeServices()
		{
			var typService = QueryService.GetTypeService();
			return Ok(typService);
		}

		[HttpGet("serviceNameList")]
		public ActionResult<IEnumerable<string>> GetServicesNameList()
		{
			var result = QueryService.GetTypeService();
			return Ok(result);
		}

		

		// POST api/<HairDresserServicesController>
		[HttpPost]
		public ActionResult CreateService([FromBody] HairDresserServiceDto modelDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var result = mapper.Map<HairDresserService>(modelDto);
			result.Service_Time = TimeSpan.Parse(modelDto.ServiceTime);
			var typeService = QueryService.GetTypeService(modelDto.TypeService);
			if (typeService != null)
			{
				result.TypeService_Id = typeService.TypeService_Id;	
			}
			else 
			{
				result.TypeService_Id = null;
			}
			result.Service_Archival = false;
			var newServiceId = CommandService.CreateService(result);
			return Created($"api/HairDresserServices/{newServiceId}", null);
		}

		// PUT api/<HairDresserServicesController>/5
		[HttpPut("{id}")]
		public ActionResult Update([FromBody] HairDresserServiceDto model, [FromRoute] int id)
		{
			var localService = QueryService.GetService(id);
			if (localService == null)
			{
				return NotFound();
			}
			localService.Service_Name = model.NameService;
			localService.Service_Price = Convert.ToDecimal(model.Price);
			localService.Service_Time = TimeSpan.Parse(model.ServiceTime);
			localService.TypeService_Id = QueryService.GetTypeService(model.TypeService).TypeService_Id;

            CommandService.UpdateService(localService);
			return Ok();
		}

		// DELETE api/<HairDresserServicesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
