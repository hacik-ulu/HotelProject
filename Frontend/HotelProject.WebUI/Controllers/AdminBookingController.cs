using HotelProject.DtoLayer.ServiceDto;
using HotelProject.WebUI.Dtos.BookingDtos;
using HotelProject.WebUI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminBookingController : Controller
    {
        private readonly HttpClient _httpClient;
        public AdminBookingController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Bookings");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ApprovedReservation(ApprovedReservationDto approvedReservationDto)
        {
            var jsonData = JsonConvert.SerializeObject(approvedReservationDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"Bookings/ChangeBookingStatus?id={approvedReservationDto.BookingId}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","AdminBooking");
            }

            return View();
        }

        public async Task<IActionResult> CancelReservation(int bookingId)
        {
            var response = await _httpClient.GetAsync($"Bookings/BookingCancel?id={bookingId}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBooking");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookingWait(int bookingId)
        {
            var response = await _httpClient.GetAsync($"Bookings/BookingWait?id={bookingId}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBooking");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var response = await _httpClient.GetAsync($"Bookings/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"Bookings", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
