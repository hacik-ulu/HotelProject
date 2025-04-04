using HotelProject.WebUI.Dtos.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly HttpClient _httpClient;
        public TestimonialController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Testimonials");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Testimonials", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var response = await _httpClient.DeleteAsync($"Testimonials/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var response = await _httpClient.GetAsync($"Testimonials/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"Testimonials", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
