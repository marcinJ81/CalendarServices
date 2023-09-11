using System.ComponentModel.DataAnnotations;

namespace CalendarServices.Model
{
	public class HairDresserService
	{
		[Key]
		public int Service_Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string Service_Name { get; set; }
		[Required]
		[Range(10,100)]
		public decimal Service_Price { get; set; }
	}
}
