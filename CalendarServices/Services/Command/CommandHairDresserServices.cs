using CalendarServices.Model;
using CalendarServices.ModelDTO;
using System.Linq;

namespace CalendarServices.Services.Command
{
	public class CommandHairDresserServices
	{
		private DataBaseContext DBContext { get; set; }
		public CommandHairDresserServices(DataBaseContext dataBaseContext)
		{
			DBContext = dataBaseContext;
		}

		public int CreateService(HairDresserService model)
		{
			DBContext.HairDressers.Add(model);
			DBContext.SaveChanges();
			return model.Service_Id;
		}

		public void UpdateService(HairDresserService model)
		{
			DBContext.HairDressers.Update(model);
			DBContext.SaveChanges();
		}
	}
}
