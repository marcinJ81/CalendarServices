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
		[ForeignKey("Service_Id")]
		public int? Service_Id { get; set; }
		[ForeignKey("Customer_Id")]
		public int? Customer_Id { get; set; }
		public ICollection<HairDresserService> HairDresserService { get; set; }
		public virtual ICollection<Customer> Customer { get; set; }

	}
}
