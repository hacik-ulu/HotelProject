namespace HotelProject.RapidApi.Models
{
    public class TripAdvisorResponseModel
    {
        public string Status { get; set; }
        public List<TripAdvisorViewModels> Data { get; set; }
    }

    public class TripAdvisorViewModels
    {
        public string HeroImgUrl { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public int UserReviewCount { get; set; }
    }
}
