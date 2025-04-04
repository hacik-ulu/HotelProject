using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string SocialMediaIcon1 { get; set; }
        public string SocialMediaIcon2 { get; set; }
        public string SocialMediaIcon3 { get; set; }

        public int StaffDetailId { get; set; }
        public StaffDetail StaffDetail { get; set; }

    }
}
