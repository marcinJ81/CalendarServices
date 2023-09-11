using System.ComponentModel.DataAnnotations;

namespace CalendarServices.Model
{
	public class StatusOfTheService
	{
		[Key]
		public int Ss_id { get; set; }
		public string Ss_Status { get; set; }
	}
}
