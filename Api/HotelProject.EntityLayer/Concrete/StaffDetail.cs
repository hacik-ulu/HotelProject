using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class StaffDetail
    {
        public int StaffDetailId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
        public bool WorkingStatus { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public Staff Staff { get; set; }

    }

}
