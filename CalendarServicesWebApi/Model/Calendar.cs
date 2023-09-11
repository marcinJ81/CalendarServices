using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarServices.Model
{
	public class Calendar
	{
		[Key]
		public int Calendar_Id { get; set; }
		public DateTime Calendar_ReservationDate { get; set; }
		public bool Calendar_Deleted { get; set; }
		public  TimeSpan Calendar_TimeService { get; set; }
		[ForeignKey("Ss_id")]
		public int  Ss_id{ get; set; }
		[ForeignKey("Service_Id")]
		public int? Service_Id { get; set; }
		[ForeignKey("Customer_Id")]
		public int? Customer_Id { get; set; }
		public virtual HairDresserService HairDresserService { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual StatusOfTheService StatusOfTheService { get; set; }
	}
}
