using AutoMapper;
using CalendarServices.Model;
using CalendarServices.ModelDTO;
using CalendarServices.Services.Command;
using CalendarServices.Services.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CalendarServices.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly IMapper mapper;
		private QueryCustormerService QueryCustomer { get; set; }
		private CommandCustomerService CommandCustomer { get; set; }

		public CustomerController(IMapper mapper, QueryCustormerService queryCustormerService, CommandCustomerService commandCustomerService)
		{
			this.mapper = mapper;
			QueryCustomer = queryCustormerService;
			CommandCustomer = commandCustomerService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
		{
			var result = mapper.Map<List<CustomerDto>>(QueryCustomer.GetCustomers());
			return Ok(result);
		}

		[HttpPost]
		public ActionResult AddCustomer([FromBody] CustomerDto modelDto)
		{
			var result = new Customer()
			{ 
				Customer_Name = modelDto.Name,
				Customer_Description = modelDto.Description,
				Customer_Email = modelDto.Email,
				Customer_Phone = modelDto.Phone,
				FavoriteSeriveces = modelDto.FavoriteSeriveces
			};
			var newCustomerid = CommandCustomer.CreateCustomer(result);
			return Created($"api/Customer/{newCustomerid}", null);
		}
	}
}
