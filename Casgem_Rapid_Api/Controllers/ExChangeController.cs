using Casgem_Rapid_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_Rapid_Api.Controllers
{
    public class ExChangeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "001ad7d37amsh06db23fe33c506ap183c14jsnd358e7ee428f" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExChangeViewModel>(body);
                return View(values.exchange_rates.ToList());
            }
        }

        public async Task<IActionResult> Index2(string x="TRY")
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency={x}&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "001ad7d37amsh06db23fe33c506ap183c14jsnd358e7ee428f" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExChangeViewModel>(body);
                return View(values.exchange_rates.ToList());
            }
        }

    }
}
