using CalendarServices.Model;
using Microsoft.EntityFrameworkCore;
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
					.Include(x => x.TypeService)
					.ToList();
		}

		public IEnumerable<TypeService> GetTypeService()
		{
			return	DataBaseContext
					.TypeServices
					.ToList();
		}

		public TypeService GetTypeService(string typeName)
		{
			return DataBaseContext
					.TypeServices
					.FirstOrDefault(x => x.TypeService_Name == typeName);				
		}
	}
}
