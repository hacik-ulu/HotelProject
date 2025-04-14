using HotelProject.RapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.RapidApi.Controllers
{
    public class TripAdvisorController : Controller
    {
        private readonly IConfiguration _configuration;
        public TripAdvisorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<TripAdvisorViewModels> tripAdvisorViewModels = new List<TripAdvisorViewModels>();

            var apiKey = _configuration["RapidApi:Key"];
            var apiHost = _configuration["RapidApi:Host"];
            var apiUrl = _configuration["RapidApi:Url"];

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(apiUrl),
                Headers =
                {
                    { "x-rapidapi-key", apiKey },
                    { "x-rapidapi-host", apiHost },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // API yanıtını deserialize et
                var tripAdvisorResponse = JsonConvert.DeserializeObject<TripAdvisorResponseModel>(body);

                // Data listesini alın
                tripAdvisorViewModels = tripAdvisorResponse?.Data;

                return View(tripAdvisorViewModels);
            }
        }
    }
}
