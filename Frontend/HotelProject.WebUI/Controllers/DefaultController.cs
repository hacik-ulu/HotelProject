using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.ServiceDtos;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;

        public DefaultController(HttpClient httpClient, IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
                return RedirectToAction("Index", "Login");

            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);

            ViewBag.Name = user.Name;
            ViewBag.Surname = user.Surname;
            ViewBag.ImageUrl = user.ImageUrl;
            ViewBag.Role = roles.FirstOrDefault(); // Rolü al

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
                return RedirectToAction("Index", "Default");
            }
            return View();
        }

    }
}