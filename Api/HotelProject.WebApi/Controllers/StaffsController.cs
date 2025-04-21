using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.StaffDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IMapper _mapper;

        public StaffsController(IStaffService staffService, IMapper mapper)
        {
            _staffService = staffService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            var values = _staffService.TGetAll();
            var result = _mapper.Map<List<ResultStaffDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetStaffById(int id)
        {
            var values = _staffService.TGetById(id);
            var result = _mapper.Map<ResultStaffDto>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateStaff(CreateStaffDto createStaffDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Staff>(createStaffDto);
            _staffService.TAdd(values);
            return Ok("İşçi başarıyla oluşturuldu!");
        }

        [HttpPut]
        public IActionResult UpdateStaff(UpdateStaffDto updateStaffDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Staff>(updateStaffDto);
            _staffService.TUpdate(values);
            return Ok("İşçi bilgileri başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var values = _staffService.TGetById(id);
            _staffService.TDelete(values);
            return Ok("İşçi bilgileri başarıyla silindi");
        }

        [HttpGet("Last4Staff")]
        public IActionResult Last4Staff()
        {
            var values = _staffService.TLast4Staff();
            return Ok(values);
        }
    }
}
