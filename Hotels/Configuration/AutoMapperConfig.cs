using AutoMapper;
using Hotels.Data;
using Hotels.Models.Country;

namespace Hotels.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
        }
    }
}
