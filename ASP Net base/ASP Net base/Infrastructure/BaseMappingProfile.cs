using AutoMapper;

namespace ASP_Net_base.Infrastructure
{
    public class BaseMappingProfile : Profile
    {
        public BaseMappingProfile()
        {
            CreateMap<DateTime, DateOnly>().ConvertUsing(src => DateOnly.FromDateTime(src));
            CreateMap<DateOnly, DateTime>().ConvertUsing(src => src.ToDateTime(new TimeOnly()));
        }
    }
}
