using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        public StaffsController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            var values = _staffService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var values = _staffService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateStaff(Staff staff)
        {
            _staffService.TAdd(new Staff
            {
                Name = staff.Name,
                SocialMediaIcon1 = staff.SocialMediaIcon1,
                SocialMediaIcon2 = staff.SocialMediaIcon2,
                SocialMediaIcon3 = staff.SocialMediaIcon3,
                Title = staff.Title
            });
            return Ok("İşçi başarıyla oluşturuldu!");
        }

        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok("İşçi bilgileri başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var values = _staffService.TGetById(id);
            _staffService.TDelete(values);
            return Ok("İşçi bilgileri başarıyla silindi");
        }
    }
}
