﻿using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.BookingDtos
{
    public class UpdateBookingDto
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RoomCount { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string AdultCount { get; set; }
        public string ChildCount { get; set; }
        public string SpecialRequest { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
