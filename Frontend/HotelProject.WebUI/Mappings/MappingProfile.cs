using AutoMapper;
using HotelProject.DtoLayer.AboutDto;
using HotelProject.DtoLayer.BookingDto;
using HotelProject.DtoLayer.SubscribeDto;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.BookingDtos;
using HotelProject.WebUI.Dtos.LoginDtos;
using HotelProject.WebUI.Dtos.RegisterDtos;
using HotelProject.WebUI.Dtos.ServiceDtos;
using HotelProject.WebUI.Dtos.StaffDtos;
using HotelProject.WebUI.Dtos.TestimonialDtos;
using CreateBookingDto = HotelProject.WebUI.Dtos.BookingDtos.CreateBookingDto;

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

            // About Mapping
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

            // Subscribe Mapping
            CreateMap<Subscribe, ResultSubscribeDto>().ReverseMap();
            CreateMap<Subscribe, UpdateSubscribeDto>().ReverseMap();

            // Subscribe Mapping
            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ApprovedReservationDto, Booking>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();

            
        }
    }
}
