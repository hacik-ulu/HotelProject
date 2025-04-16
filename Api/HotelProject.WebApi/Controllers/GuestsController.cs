using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.GuestDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _guestService;
        private readonly IMapper _mapper;

        public GuestsController(IGuestService guestService, IMapper mapper)
        {
            _guestService = guestService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            var values = _guestService.TGetAll();
            var result = _mapper.Map<List<ResultGuestDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetGuestById(int id)
        {
            var values = _guestService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateGuest(CreateGuestDto createGuestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Guest>(createGuestDto);
            _guestService.TAdd(values);
            return Ok("Misafir başarıyla oluşturuldu!");
        }

        [HttpPut]
        public IActionResult UpdateGuest(UpdateGuestDto updateGuestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Guest>(updateGuestDto);
            _guestService.TUpdate(values);
            return Ok("Misafir bilgileri başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var values = _guestService.TGetById(id);
            _guestService.TDelete(values);
            return Ok("Misafir bilgileri başarıyla silindi!");
        }
    }

}
