using CalendarServices.Model;
using System.Collections.Generic;
using System.Linq;

namespace CalendarServices.SeedModel
{
	public class SeederServices
	{
		private DataBaseContext DataBaseContext { get; set; }
		public SeederServices(DataBaseContext dataBaseContext)
		{
			this.DataBaseContext = dataBaseContext;
		}

		public void Seed()
		{
			if (DataBaseContext.Database.CanConnect())
			{
				if (!DataBaseContext.HairDressers.Any())
				{
					var services = GetServices();
					DataBaseContext.HairDressers.AddRange(services);
					DataBaseContext.SaveChanges();
				}
				if (!DataBaseContext.TypeServices.Any())
				{
					var typeServices = GetTypeServices();
					DataBaseContext.TypeServices.AddRange(typeServices);
					DataBaseContext.SaveChanges();
				}
			}
		}

		private IEnumerable<HairDresserService> GetServices()
		{
			return new List<HairDresserService>()
			{
				new HairDresserService
					{
						Service_Name = "strzyżenie",
						Service_Price = 20
					},
				new HairDresserService
					{
						Service_Name = "koloryzacja",
						Service_Price = 80
					}
			};
		}

		private IEnumerable<TypeService> GetTypeServices()
		{
			return new List<TypeService>()
			{
				new TypeService
				{
					TypeService_Name = "Kobieta"
				},
				new TypeService
				{
					TypeService_Name = "Meżczyzna"
				},
				new TypeService {
					TypeService_Name = "Dziecko"
				}
			};
		}
	}
}
