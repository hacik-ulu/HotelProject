using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.SendMessageDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessagesController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;
        private readonly IMapper _mapper;

        public SendMessagesController(ISendMessageService sendMessageService, IMapper mapper)
        {
            _sendMessageService = sendMessageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _sendMessageService.TGetAll();
            var result = _mapper.Map<List<ResultSendMessageDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageById(int id)
        {
            var values = _sendMessageService.TGetById(id);
            var result = _mapper.Map<ResultSendMessageDto>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateSendMessageDto createSendMessageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<SendMessage>(createSendMessageDto);
            _sendMessageService.TAdd(values);
            return Ok("Mesaj başarıyla gönderildi!");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateSendMessageDto updateSendMessageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<SendMessage>(updateSendMessageDto);
            _sendMessageService.TUpdate(values);
            return Ok("Mesaj başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var values = _sendMessageService.TGetById(id);
            _sendMessageService.TDelete(values);
            return Ok("Mesaj başarıyla silindi.");
        }
    }

}
