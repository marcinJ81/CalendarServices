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
				.ForMember(x => x.Name, y=> y.MapFrom(z => z.Service_Name))
				.ForMember(x => x.Price, y => y.MapFrom(z => string.Format("{0:0.00}", z.Service_Price)));

			CreateMap<HairDresserServiceDto, HairDresserService>()
				.ForMember(x => x.Service_Name, y => y.MapFrom(z => z.Name))
				.ForMember(x => x.Service_Price, y => y.MapFrom(z => Convert.ToDecimal(z.Price)));

		}
	}
}
