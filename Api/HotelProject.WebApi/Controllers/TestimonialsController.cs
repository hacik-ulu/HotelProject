using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.TestimonialDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetAll();
            var dtoValues = _mapper.Map<List<ResultTestimonialDto>>(values);
            return Ok(dtoValues);
        }

        [HttpGet("GetTestimonialById")]
        public IActionResult GetTestimonialById(int id)
        {
            var values = _testimonialService.TGetById(id);
            var dtoValue = _mapper.Map<ResultTestimonialDto>(values);
            return Ok(dtoValue);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(testimonial);
            return Ok("Referans başarıyla oluşturuldu!");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(testimonial);
            return Ok("Referans bilgileri başarıyla güncellendi!");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);
            _testimonialService.TDelete(values);
            return Ok("Referans bilgileri başarıyla silindi");
        }
    }
}
