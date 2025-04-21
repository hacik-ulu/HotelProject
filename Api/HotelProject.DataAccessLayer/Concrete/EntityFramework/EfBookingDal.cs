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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly Context _context;
        public EfBookingDal(Context context) : base(context)
        {
            _context = context;
        }

        public void BookingStatusChangeApproved(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangeApproved3(int id)
        {
            var values = _context.Bookings.Find(id);
            values.Status = "Onaylandı";
            _context.SaveChanges();
        }

        public void BookingStatusChangeCancel(int id)
        {
            var values = _context.Bookings.Find(id);
            values.Status = "İptal Edildi";
            _context.SaveChanges();
        }

        public void BookingStatusChangeWait(int id)
        {
            var values = _context.Bookings.Find(id);
            values.Status = "Müşteri Aranacak";
            _context.SaveChanges();
        }

        public int GetBookingCount()
        {
            return _context.Bookings.Count();
        }

        public List<Booking> Last6Bookings()
        {
            var values = _context.Bookings.OrderByDescending(x => x.BookingId).Take(6).ToList();
            return values;
        }
    }
}
