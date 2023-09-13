using System.ComponentModel.DataAnnotations;

namespace CalendarServices.Model
{
	public class TypeService
	{
		[Key]
		public int TypeService_Id { get; set; }
		public string TypeService_Name { get; set; }
	}
}
