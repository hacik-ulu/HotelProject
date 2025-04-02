using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var values = _roomService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateRoom(Room room)
        {
            _roomService.TAdd(new Room
            {
                BathCount = room.BathCount,
                BedCount = room.BedCount,
                CoverImage = room.CoverImage,
                Description = room.Description,
                Price = room.Price,
                RoomNumber = room.RoomNumber,
                Wifi = room.Wifi,
                Title = room.Title
            });
            return Ok("Oda başarıyla oluşturuldu!");
        }

        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _roomService.TUpdate(room);
            return Ok("Oda bilgileri başarıyla güncellendi!");
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var values = _roomService.TGetById(id);
            _roomService.TDelete(values);
            return Ok("Oda bilgileri başarıyla silindi!");
        }

    }
}
