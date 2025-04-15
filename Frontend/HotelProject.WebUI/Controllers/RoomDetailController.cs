using HotelProject.WebUI.Dtos.RoomDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class RoomDetailController : Controller
    {
        private readonly HttpClient _httpClient;

        public RoomDetailController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
        }

        public async Task<IActionResult> Index(int id)
        {
            var response = await _httpClient.GetAsync($"Rooms/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultRoomDto>(jsonData);
                return View(value); 
            }

            return View();
        }

    }
}
