using System.ComponentModel.DataAnnotations;

namespace CalendarServices.Model
{
	public class Customer
	{
		[Key]
		public int Customer_Id { get; set; }
		public string Customer_Name { get; set; }
		public string Customer_Phone { get; set; }
		public string Customer_Email { get; set; }
		public string Customer_Description { get; set; }
	}
}
