using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.Interfaces;

namespace WeatherAttack.Infra.Services
{
    public sealed class OpenWeatherMapWebService : IOpenWeatherMapService
    {
        private string OpenWeatherMapUrl { get; }

        private string OpenWeatherMapKey { get; }

        private string ApplicationJson { get; } = "application/json";

        public OpenWeatherMapWebService(string openWeatherMapUrl, string openWeatherMapKey)
        {
            OpenWeatherMapKey = openWeatherMapKey;
            OpenWeatherMapUrl = openWeatherMapUrl;
        }

        public async Task<CurrentWeatherRequestDto> GetCurrentWeatherByCoordinates(double latitude, double longitude)
        {
            var uriString = $"{OpenWeatherMapUrl}?lat={latitude.ToString()}&lon={longitude.ToString()}&units=metric&appid={OpenWeatherMapKey}";

            var request = CreateRequest(uriString);

            using (var response = await request.GetResponseAsync())
            {
                using (var responseContent = response.GetResponseStream())
                {
                    return await JsonSerializer.DeserializeAsync<CurrentWeatherRequestDto>(responseContent);
                }
            }
        }

        private HttpWebRequest CreateRequest(string uri) => CreateRequest(new Uri(uri));
        private HttpWebRequest CreateRequest(Uri uri)
        {
            var request = WebRequest.CreateHttp(uri);
            request.Accept = ApplicationJson;
            request.ContentType = ApplicationJson;

            return request;
        }
    }
}
