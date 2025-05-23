﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete.EntityFramework;
using HotelProject.DataAccessLayer.Concrete.Repositories;

namespace HotelProject.WebApi.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Generic Service
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

            // Room Service
            services.AddScoped<IRoomService, RoomManager>();
            services.AddScoped<IRoomDal, EfRoomDal>();

            // Service
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceDal, EfServiceDal>();

            // Staff
            services.AddScoped<IStaffService, StaffManager>();
            services.AddScoped<IStaffDal, EfStaffDal>();

            // Subscribe
            services.AddScoped<ISubscribeService, SubscribeManager>();
            services.AddScoped<ISubscribeDal, EfSubscribeDal>();

            // Testimonial
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();

            // About
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();

            // Booking
            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<IBookingDal, EfBookingDal>();

            // Contact
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();

            // Guest
            services.AddScoped<IGuestService, GuestManager>();
            services.AddScoped<IGuestDal, EfGuestDal>();

            // SendMessage
            services.AddScoped<ISendMessageService, SendMessageManager>();
            services.AddScoped<ISendMessageDal, EfSendMessageDal>();

            // MessageCategory
            services.AddScoped<IMessageCategoryService, MessageCategoryManager>();
            services.AddScoped<IMessageCategoryDal, EfMessageCategoryDal>();

            // WorkLocation
            services.AddScoped<IWorkLocationService, WorkLocationManager>();
            services.AddScoped<IWorkLocationDal, EfWorkLocationDal>();

            // AppUser
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            return services;
        }
    }
}
