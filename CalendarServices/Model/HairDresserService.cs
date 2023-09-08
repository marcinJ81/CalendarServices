using System.ComponentModel.DataAnnotations;

namespace CalendarServices.Model
{
	public class HairDresserService
	{
		[Key]
		public int Service_Id { get; set; }
		public string Service_Name { get; set; }
		public decimal Service_Price { get; set; }
	}
}
