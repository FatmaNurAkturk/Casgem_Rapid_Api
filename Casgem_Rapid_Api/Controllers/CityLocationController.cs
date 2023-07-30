﻿using Casgem_Rapid_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_Rapid_Api.Controllers
{
    public class CityLocationController : Controller
    {
        public async Task<IActionResult> Index(string cityname = "London")
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityname}&locale=tr"),
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
                var value = JsonConvert.DeserializeObject<List<LocationCitynameViewModel>>(body);
                return View(body.Take(1).ToList());
            }
        }
    }
}
