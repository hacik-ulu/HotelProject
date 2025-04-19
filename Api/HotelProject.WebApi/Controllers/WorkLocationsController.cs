using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.WorkLocationDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationsController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;
        private readonly IMapper _mapper;

        public WorkLocationsController(IWorkLocationService workLocationService, IMapper mapper)
        {
            _workLocationService = workLocationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult WorkLocationList()
        {
            var values = _workLocationService.TGetAll();
            var result = _mapper.Map<List<ResultWorkLocationDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetWorkLocationById(int id)
        {
            var values = _workLocationService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateWorkLocation(CreateWorkLocationDto createWorkLocationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<WorkLocation>(createWorkLocationDto);
            _workLocationService.TAdd(values);
            return Ok("Çalışma lokasyonu başarıyla oluşturuldu!");
        }

        [HttpPut]
        public IActionResult UpdateWorkLocation(UpdateWorkLocationDto updateWorkLocationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<WorkLocation>(updateWorkLocationDto);
            _workLocationService.TUpdate(values);
            return Ok("Çalışma lokasyonu başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWorkLocation(int id)
        {
            var values = _workLocationService.TGetById(id);
            _workLocationService.TDelete(values);
            return Ok("Çalışma lokasyonu başarıyla silindi!");
        }
    }

}
