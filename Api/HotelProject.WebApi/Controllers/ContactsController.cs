using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.ContactDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetAll();
            var result = _mapper.Map<List<ResultContactDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var value = _contactService.TGetById(id);
            var result = _mapper.Map<ResultContactDto>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var value = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(value);
            return Ok("İletişim bilgisi başarıyla eklendi!");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("İletişim bilgisi başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("İletişim bilgisi başarıyla silindi!");
        }
    }
}
