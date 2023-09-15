using CalendarServices.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CalendarServices.Services.Query
{
	public class QueryCustormerService
	{
		private DataBaseContext DataBaseContext { get; set; }
		public QueryCustormerService(DataBaseContext dataBaseContext)
		{
			DataBaseContext = dataBaseContext;
		}

		public IEnumerable<Customer> GetCustomers()
		{
			return DataBaseContext
					.Customers
					.Include(x => x.TypeService)
					.ToList();
		}

		public Customer GetCustomer(int customerId)
		{
			return DataBaseContext
					.Customers
					.Include(x => x.TypeService)
					.FirstOrDefault(x => x.Customer_Id == customerId);
		}
	}
}
