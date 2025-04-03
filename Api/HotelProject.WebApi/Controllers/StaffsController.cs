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
            var dtoValues = _mapper.Map<List<ResultStaffDto>>(values);
            return Ok(dtoValues);
        }

        [HttpGet("GetStaffById")]
        public IActionResult GetStaffById(int id)
        {
            var values = _staffService.TGetById(id);
            var dtoValue = _mapper.Map<ResultStaffDto>(values);
            return Ok(dtoValue);
        }

        [HttpPost]
        public IActionResult CreateStaff(CreateStaffDto createStaffDto)
        {
            var staff = _mapper.Map<Staff>(createStaffDto);
            _staffService.TAdd(staff);
            return Ok("İşçi başarıyla oluşturuldu!");
        }

        [HttpPut]
        public IActionResult UpdateStaff(UpdateStaffDto updateStaffDto)
        {
            var staff = _mapper.Map<Staff>(updateStaffDto);
            _staffService.TUpdate(staff);
            return Ok("İşçi bilgileri başarıyla güncellendi!");
        }

        [HttpDelete]
        public IActionResult DeleteStaff(int id)
        {
            var values = _staffService.TGetById(id);
            _staffService.TDelete(values);
            return Ok("İşçi bilgileri başarıyla silindi");
        }
    }
}
