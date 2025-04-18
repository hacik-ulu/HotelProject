using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.MessageCategoryDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MessageCategoriesController : ControllerBase
    {
        private readonly IMessageCategoryService _messageCategoryService;
        private readonly IMapper _mapper;

        public MessageCategoriesController(IMessageCategoryService messageCategoryService, IMapper mapper)
        {
            _messageCategoryService = messageCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMessageCategories()
        {
            var values = _messageCategoryService.TGetAll();
            var result = _mapper.Map<List<ResultMessageCategoryDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageCategoryById(int id)
        {
            var value = _messageCategoryService.TGetById(id);
            if (value == null)
            {
                return NotFound("Belirtilen ID'ye ait kategori bulunamadı.");
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateMessageCategory(CreateMessageCategoryDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _mapper.Map<MessageCategory>(createDto);
            _messageCategoryService.TAdd(entity);
            return Ok("Mesaj kategorisi başarıyla oluşturuldu!");
        }

        [HttpPut]
        public IActionResult UpdateMessageCategory(UpdateMessageCategoryDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _mapper.Map<MessageCategory>(updateDto);
            _messageCategoryService.TUpdate(entity);
            return Ok("Mesaj kategorisi başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessageCategory(int id)
        {
            var entity = _messageCategoryService.TGetById(id);
            if (entity == null)
            {
                return NotFound("Silinecek kategori bulunamadı.");
            }

            _messageCategoryService.TDelete(entity);
            return Ok("Mesaj kategorisi başarıyla silindi!");
        }
    }

}
