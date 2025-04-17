using HotelProject.WebUI.Dtos.ContactDtos;
using HotelProject.WebUI.Dtos.SendMessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly HttpClient _httpClient;
        public AdminContactController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
        }

        public async Task<IActionResult> Inbox()
        {
            var response = await _httpClient.GetAsync("Contacts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Sendbox()
        {
            var response = await _httpClient.GetAsync("SendMessages");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
                return View(values);
            }
            return View();
        }



        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
        {
            createSendMessageDto.SenderEmail = "admin@gmail.com";
            createSendMessageDto.SenderName = "admin";
            createSendMessageDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            ModelState.Clear();
            TryValidateModel(createSendMessageDto);

            if (!ModelState.IsValid)
            {
                return View();
            }

            var jsonData = JsonConvert.SerializeObject(createSendMessageDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("SendMessages", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }

            return View();
        }
        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }

        public PartialViewResult SideBarAdminCategoryPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> MessageDetailsBySendbox(int id)
        {
            var response = await _httpClient.GetAsync($"SendMessages/GetSendMessage/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var response = await _httpClient.GetAsync($"Contacts/GetSendMessage/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}