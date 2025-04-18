using HotelProject.WebUI.Dtos.ContactDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly HttpClient _httpClient;
        public ContactController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            createContactDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            var jsonData = JsonConvert.SerializeObject(createContactDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Contacts", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            return View();
        }
    }
}
