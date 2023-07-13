using AutoMapper;
using HotelListing.data;
using HotelListing.Models;
using Microsoft.Build.Framework.Profiler;

namespace HotelListing.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<country, CountryDTO>().ReverseMap();
            CreateMap<country, CreateCountryDTO>().ReverseMap();
            CreateMap<hotel, hotelDTO>().ReverseMap();
            CreateMap<hotel, createhotelDTO>().ReverseMap();
        }
    }
}
