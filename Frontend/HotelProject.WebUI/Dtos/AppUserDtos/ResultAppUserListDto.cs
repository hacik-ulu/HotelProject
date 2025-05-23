﻿using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Dtos.AppUserDtos
{
    public class ResultAppUserListDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public string WorkDepartment { get; set; }
        public int WorkLocationId { get; set; }
    }
}
