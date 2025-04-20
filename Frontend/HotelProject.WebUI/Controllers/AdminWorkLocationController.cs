using HotelProject.WebUI.Dtos.WorkLocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminWorkLocation : Controller
    {
        private readonly HttpClient _httpClient;
        public AdminWorkLocation(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("WorkLocations");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWorkLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddWorkLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkLocation(CreateWorkLocationDto createWorkLocationDto)
        {
            var jsonData = JsonConvert.SerializeObject(createWorkLocationDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("WorkLocations", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteWorkLocation(int id)
        {
            var response = await _httpClient.DeleteAsync($"WorkLocations/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateWorkLocation(int id)
        {
            var response = await _httpClient.GetAsync($"WorkLocations/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateWorkLocationDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWorkLocation(UpdateWorkLocationDto updateWorkLocationDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateWorkLocationDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"WorkLocations", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
