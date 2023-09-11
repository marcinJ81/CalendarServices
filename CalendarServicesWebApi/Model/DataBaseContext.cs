using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CalendarServices.Model
{
	public class DataBaseContext : DbContext
	{
		private readonly IConfiguration _configuration;
		public DbSet<Customer> Customers { get; set; }
		public DbSet<HairDresserService> HairDressers { get; set; }
		public DbSet<Calendar> Calendars { get; set; }
		public DbSet<StatusOfTheService> StatusOfTheServices { get; set; }

		public DataBaseContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_configuration.GetConnectionString("db"));
		}
	}
}
