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
    public class EfSendMessageDal : GenericRepository<SendMessage>, ISendMessageDal
    {
        private readonly Context _context;
        public EfSendMessageDal(Context context) : base(context)
        {
            _context = context;
        }

        public int GetSendMessageCount()
        {
            return _context.SendMessages.Count();
        }
    }
}
