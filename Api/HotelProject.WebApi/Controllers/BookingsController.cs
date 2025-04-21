using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.BookingDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetAll();
            var result = _mapper.Map<List<ResultBookingDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var values = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(values);
            return Ok("Rezervasyon başarıyla oluşturuldu!");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(values);
            return Ok("Rezervasyon bilgileri başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok("Rezervasyon başarıyla silindi!");
        }

        [HttpPut("ChangeBookingStatus")]
        public IActionResult ChangeBookingStatus(int id)
        {
            _bookingService.TBookingStatusChangeApproved(id);
            return Ok("Rezervasyon durumu güncellendi");
        }

        [HttpGet("Last6Booking")]
        public IActionResult Last6Booking()
        {
            var values = _bookingService.TLast6Bookings();
            return Ok(values);
        }

        [HttpGet("BookingAproved")]
        public IActionResult BookingAproved(int id)
        {
            _bookingService.TBookingStatusChangeApproved3(id);
            return Ok();
        }

        [HttpGet("BookingCancel")]
        public IActionResult BookingCancel(int id)
        {
            _bookingService.TBookingStatusChangeCancel(id);
            return Ok();
        }
        [HttpGet("BookingWait")]
        public IActionResult BookingWait(int id)
        {
            _bookingService.TBookingStatusChangeWait(id);
            return Ok();
        }
    }
}
