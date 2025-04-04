using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.SubscribeDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribesController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;
        private readonly IMapper _mapper;

        public SubscribesController(ISubscribeService subscribeService, IMapper mapper)
        {
            _subscribeService = subscribeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.TGetAll();
            var result = _mapper.Map<List<ResultSubscribeDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubscribeById(int id)
        {
            var values = _subscribeService.TGetById(id);
            var result = _mapper.Map<ResultSubscribeDto>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateSubscribe(CreateSubscribeDto createSubscribeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Subscribe>(createSubscribeDto);
            _subscribeService.TAdd(values);
            return Ok("Abonelik başarıyla oluşturuldu!");
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(UpdateSubscribeDto updateSubscribeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Subscribe>(updateSubscribeDto);
            _subscribeService.TUpdate(values);
            return Ok("Abonelik bilgileri başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubscribe(int id)
        {
            var values = _subscribeService.TGetById(id);
            _subscribeService.TDelete(values);
            return Ok("Abonelik bilgileri başarıyla silindi");
        }
    }
}
