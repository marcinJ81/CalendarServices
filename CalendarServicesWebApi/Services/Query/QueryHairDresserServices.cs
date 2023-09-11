using CalendarServices.Model;
using System.Collections.Generic;
using System.Linq;

namespace CalendarServices.Services.Query
{
	public class QueryHairDresserServices
	{
		private DataBaseContext DataBaseContext { get; set; }
		public QueryHairDresserServices(DataBaseContext dataBaseContext)
		{
			DataBaseContext = dataBaseContext;
		}

		public HairDresserService GetService(int id)
		{
			return DataBaseContext
					.HairDressers
					.FirstOrDefault(x => x.Service_Id == id)
;		}

		public IEnumerable<HairDresserService> GetServices()
		{
			return DataBaseContext
					.HairDressers
					.ToList();
		}
	}
}
