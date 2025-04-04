namespace HotelProject.WebUI.Extensions
{
    public static class HttpClientExtensions
    {
        public static IServiceCollection AddCustomHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient();

            return services;
        }
    }
}
