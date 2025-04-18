using HotelProject.WebUI.Dtos.ServiceDtos;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly HttpClient _httpClient;
        public DefaultController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _SubscribeComponentPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _SubscribeComponentPartial(CreateSubscribeDto createSubscribeDto)
        {
            var jsonData = JsonConvert.SerializeObject(createSubscribeDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Subscribes", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();
        }

    }
}
