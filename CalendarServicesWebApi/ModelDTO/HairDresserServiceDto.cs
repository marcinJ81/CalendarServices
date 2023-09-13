using System;
using System.ComponentModel.DataAnnotations;

namespace CalendarServices.ModelDTO
{
	public class HairDresserServiceDto
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string NameService { get; set; }
		[Required]
		[Range(10,1000)]
		public string Price { get; set; }
		public TimeSpan ServiceTime { get; set; } 
		public String TypeService { get; set; }
	}
}
