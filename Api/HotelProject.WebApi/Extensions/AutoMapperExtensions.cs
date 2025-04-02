using AutoMapper;

namespace HotelProject.WebApi.Extensions
{
    public static class AutoMapperExtensions
    {
        public static TDestination MapTo<TDestination>(this IMapper mapper, object source)
        {
            return mapper.Map<TDestination>(source);
        }
    }


}
