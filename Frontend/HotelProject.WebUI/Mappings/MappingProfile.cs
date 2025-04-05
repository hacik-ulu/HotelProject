using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.ServiceDtos;
using HotelProject.WebUI.Dtos.StaffDtos;
using HotelProject.WebUI.Dtos.TestimonialDtos;

namespace HotelProject.WebUI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Service Mapping
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();

            // Staff Mapping
            CreateMap<Staff, CreateStaffDto>().ReverseMap();
            CreateMap<Staff, ResultStaffDto>().ReverseMap();
            CreateMap<Staff, UpdateStaffDto>().ReverseMap();

            // Testimonial Mapping
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();

        }
    }
}
