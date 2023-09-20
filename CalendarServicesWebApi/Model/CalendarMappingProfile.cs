using AutoMapper;
using CalendarServices.ModelDTO;
using System;

namespace CalendarServices.Model
{
	public class CalendarMappingProfile : Profile
	{
		public CalendarMappingProfile()
		{
			CreateMap<HairDresserService, HairDresserServiceDto>()
				.ForMember(x => x.Id, y => y.MapFrom(z => z.Service_Id))
				.ForMember(x => x.NameService, y => y.MapFrom(z => z.Service_Name))
				.ForMember(x => x.Price, y => y.MapFrom(z => string.Format("{0:0.00}", z.Service_Price)))
				.ForMember(x => x.ServiceTime, y => y.MapFrom(z => string.Format("{0}:{1}", z.Service_Time.Hours, z.Service_Time.Minutes)))
				.ForMember(x => x.TypeService, y => y.MapFrom(z => z.TypeService != null ? z.TypeService.TypeService_Name : String.Empty));

			CreateMap<HairDresserServiceDto, HairDresserService>()
				.ForMember(x => x.Service_Name, y => y.MapFrom(z => z.NameService))
				.ForMember(x => x.Service_Price, y => y.MapFrom(z => Convert.ToDecimal(z.Price)))
				.ForMember(x => x.TypeService, y => y.Ignore())
				.ForMember(x => x.TypeService_Id, y => y.Ignore());

			CreateMap<Customer, CustomerDto>()
				.ForMember(x => x.Id, y => y.MapFrom(z => z.Customer_Id))
				.ForMember(x => x.Name, y => y.MapFrom(z => z.Customer_Name))
				.ForMember(x => x.Email, y => y.MapFrom(z => z.Customer_Email))
				.ForMember(x => x.Phone, y => y.MapFrom(z => z.Customer_Phone))
				.ForMember(x => x.Description, y => y.MapFrom(z => z.Customer_Description));
		}
	}
}
