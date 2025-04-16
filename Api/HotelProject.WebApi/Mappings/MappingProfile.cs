using AutoMapper;
using HotelProject.DtoLayer.AboutDto;
using HotelProject.DtoLayer.BookingDto;
using HotelProject.DtoLayer.ContactDto;
using HotelProject.DtoLayer.GuestDto;
using HotelProject.DtoLayer.Room;
using HotelProject.DtoLayer.ServiceDto;
using HotelProject.DtoLayer.StaffDto;
using HotelProject.DtoLayer.SubscribeDto;
using HotelProject.DtoLayer.TestimonialDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Room Mapping
            CreateMap<Room, CreateRoomDto>().ReverseMap();
            CreateMap<Room, ResultRoomDto>().ReverseMap();
            CreateMap<Room, UpdateRoomDto>().ReverseMap();

            // Service Mapping
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();

            // Staff Mapping
            CreateMap<Staff, CreateStaffDto>().ReverseMap();
            CreateMap<Staff, ResultStaffDto>().ReverseMap();
            CreateMap<Staff, UpdateStaffDto>().ReverseMap();

            // Subscribe Mapping
            CreateMap<Subscribe, CreateSubscribeDto>().ReverseMap();
            CreateMap<Subscribe, ResultSubscribeDto>().ReverseMap();
            CreateMap<Subscribe, UpdateSubscribeDto>().ReverseMap();

            // Testimonial Mapping
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();

            // About Mapping
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

            //Booking Mapping
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();

            //Contact Mapping
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, InboxContactDto>().ReverseMap();

            //Guest Mapping
            CreateMap<Guest, CreateGuestDto>().ReverseMap();
            CreateMap<Guest, ResultGuestDto>().ReverseMap();
            CreateMap<Guest, UpdateGuestDto>().ReverseMap();
        }
    }
}
