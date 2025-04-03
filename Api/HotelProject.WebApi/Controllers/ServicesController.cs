using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Service;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServicesController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetAll();
            var dtoValues = _mapper.Map<List<ResultServiceDto>>(values);
            return Ok(dtoValues);
        }

        [HttpGet("GetServiceById")]
        public IActionResult GetServiceById(int id)
        {
            var values = _serviceService.TGetById(id);
            var dtoValue = _mapper.Map<ResultServiceDto>(values);
            return Ok(dtoValue);
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDto createServiceDto)
        {
            var service = _mapper.Map<Service>(createServiceDto);
            _serviceService.TAdd(service);
            return Ok("Hizmet başarıyla oluşturuldu!");
        }

        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
        {
            var service = _mapper.Map<Service>(updateServiceDto);
            _serviceService.TUpdate(service);
            return Ok("Hizmet bilgileri başarıyla güncellendi!");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.TGetById(id);
            _serviceService.TDelete(values);
            return Ok("Hizmet bilgileri başarıyla silindi");
        }
    }
}
