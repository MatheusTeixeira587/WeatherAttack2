using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.Interfaces;

namespace WeatherAttack.Infra.Services
{
    public class OpenWeatherMapWebService : IOpenWeatherMapService
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

            Uri uri = new Uri(uriString);

            var request = WebRequest.CreateHttp(uri);
            request.Accept = ApplicationJson;
            request.ContentType = ApplicationJson;

            using (var response = await request.GetResponseAsync())
            {
                using (var responseContent = response.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(responseContent))
                    {
                        var jsonResponse = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<CurrentWeatherRequestDto>(
                            jsonResponse
                        );
                    }
                }
            }
        }
    }
}
