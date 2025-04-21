using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete.Database;
using HotelProject.DataAccessLayer.Concrete.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        private readonly Context _context;
        public EfStaffDal(Context context) : base(context)
        {
            _context = context;
        }

        public int GetStaffCount()
        {
            return _context.Staffs.Count();
        }

        public List<Staff> Last4Staff()
        {   
            var values = _context.Staffs.OrderByDescending(x => x.StaffId).Take(4).ToList();
            return values;
        }
    }
}
