using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
		public string FavoriteSeriveces { get; set; }
		[ForeignKey("TypeService_Id")]
		public int? TypeServices_id { get; set; }
		public virtual TypeService TypeService { get; set; }
	}
}
