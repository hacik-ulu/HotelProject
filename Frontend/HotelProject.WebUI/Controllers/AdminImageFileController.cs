using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        private readonly HttpClient _httpClient;
        public AdminImageFileController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            try
            {
                var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                var bytes = stream.ToArray();

                ByteArrayContent byteArrayContent = new(bytes);
                byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                MultipartFormDataContent multipartFormDataContent = new()
                {
                    { byteArrayContent, "file", file.FileName }
                };

                var response = await _httpClient.PostAsync("FileImages", multipartFormDataContent);

                if (response.IsSuccessStatusCode)
                {
                    TempData["UploadMessage"] = "Dosya başarıyla yüklendi.";
                }
                else
                {
                    TempData["UploadMessage"] = "Dosya yüklenirken bir hata oluştu.";
                }
            }
            catch (Exception ex)
            {
                TempData["UploadMessage"] = "Bir hata meydana geldi: " + ex.Message;
            }
            return View();
        }
    }
}