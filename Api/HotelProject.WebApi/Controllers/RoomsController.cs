using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.AboutDto;
using HotelProject.DtoLayer.Room;
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
        private readonly IMapper _mapper;
        public RoomsController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.TGetAll();
            var result = _mapper.Map<List<ResultRoomDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            var values = _roomService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateRoom(CreateRoomDto createRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(createRoomDto);
            _roomService.TAdd(values);
            return Ok("Oda başarıyla oluşturuldu!");

        }

        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(updateRoomDto);
            _roomService.TUpdate(values);
            return Ok("Oda bilgileri başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var values = _roomService.TGetById(id);
            _roomService.TDelete(values);
            return Ok("Oda bilgileri başarıyla silindi!");
        }

    }
}