using CalendarServices.Model;

namespace CalendarServices.Services.Command
{
	public class CommandCustomerService
	{
		private DataBaseContext DBContext { get; set; }

		public CommandCustomerService(DataBaseContext dataBaseContext)
		{
			DBContext = dataBaseContext;
		}

		public int CreateCustomer(Customer model)
		{
			DBContext.Customers.Add(model);
			DBContext.SaveChanges();
			return model.Customer_Id;
		}
	}
}
