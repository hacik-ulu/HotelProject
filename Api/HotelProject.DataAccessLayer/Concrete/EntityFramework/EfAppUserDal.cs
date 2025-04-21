using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete.Database;
using HotelProject.DataAccessLayer.Concrete.Repositories;
using HotelProject.DtoLayer.AppUserDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        private readonly Context _context;
        public EfAppUserDal(Context context) : base(context)
        {
            _context = context;
        }

        public int GetAppUserCount()
        {
            return _context.Users.Count();
        }

        public List<ResultAppUserListDto> UserListWithWorkLocation()
        {
            var result = _context.Users
                .Include(u => u.WorkLocation)
                .Select(u => new ResultAppUserListDto
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    ImageUrl = u.ImageUrl,
                    City = u.WorkLocation != null ? u.WorkLocation.City : null,
                    WorkDepartment = u.WorkLocation != null ? u.WorkLocation.Name : null,
                    WorkLocationId = u.WorkLocation != null ? u.WorkLocation.WorkLocationId : 0
                })
                .ToList();

            return result;
        }

    }
}
