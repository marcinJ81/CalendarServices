using AutoMapper;
using CalendarServices.Model;
using CalendarServices.SeedModel;
using CalendarServices.Services.Command;
using CalendarServices.Services.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarServices
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DataBaseContext>();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddAutoMapper(this.GetType().Assembly);
			services.AddScoped<SeederServices>();
			services.AddScoped<QueryHairDresserServices>();
			services.AddScoped<CommandHairDresserServices>();
			services.AddScoped<QueryCustormerService>();
			services.AddScoped<CommandCustomerService>();
			services.AddCors();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeederServices seederServices)
		{
			seederServices.Seed();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
			app.UseMvc();
		}
	}
}
