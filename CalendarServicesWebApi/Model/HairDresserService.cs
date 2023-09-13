using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarServices.Model
{
	public class HairDresserService
	{
		[Key]
		public int Service_Id { get; set; }
		[Required]
		public string Service_Name { get; set; }
		[Required]
		public decimal Service_Price { get; set; }
		public TimeSpan Service_Time { get; set; }
		[ForeignKey("TypeService_Id")]
		public int? TypeService_Id { get; set; }
		public virtual TypeService TypeService { get; set; }
		public bool Service_Archival { get; set; }
	}
}
