using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete.Database;
using HotelProject.DataAccessLayer.Concrete.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Concrete.EntityFramework
{
    public class EfRoomDal : GenericRepository<Room>, IRoomDal
    {
        private readonly Context _context;
        public EfRoomDal(Context context) : base(context)
        {
            _context = context;
        }

        public int GetRoomCount()
        {
            return _context.Rooms.Count();
        }
    }
}
