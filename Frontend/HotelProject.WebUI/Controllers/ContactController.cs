using HotelProject.DtoLayer.MessageCategoryDto;
using HotelProject.WebUI.Dtos.ContactDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("MessageCategories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);
                var selectList = values?.Select(x => new SelectListItem
                {
                    Text = x.MessageCategoryName,
                    Value = x.MessageCategoryId.ToString()
                }).ToList();

                ViewBag.MessageCategories = selectList;

                return View();
            }
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
            createContactDto.Date = DateTime.Now; 

            var jsonData = JsonConvert.SerializeObject(createContactDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Contacts", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Mesajınız başarıyla gönderildi!";
                TempData["MessageType"] = "success"; 
                return RedirectToAction("Index", "Default");
            }

            TempData["Message"] = "Mesaj gönderilirken bir hata oluştu. Lütfen tekrar deneyin.";
            TempData["MessageType"] = "error"; 
            return View();
        }

    }
}
