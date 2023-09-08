using CalendarServices.Model;
using CalendarServices.Services.Command;
using CalendarServices.Services.Query;

namespace CalendarServices.Services
{
	public class HairDresserServiceHandler
	{
		private DataBaseContext DBContext { get; set; }
		private CommandHairDresserServices CommandHandler { get; set; }
		private QueryHairDresserServices QueryHandler { get; set; }
		public HairDresserServiceHandler(DataBaseContext dataBaseContext, CommandHairDresserServices commandHairDresserServices, QueryHairDresserServices queryHairDresserServices)
		{
			DBContext = dataBaseContext;
			CommandHandler = commandHairDresserServices;
			QueryHandler = queryHairDresserServices;
		}
	}
}
