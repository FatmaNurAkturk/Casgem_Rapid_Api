using Casgem_Rapid_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_Rapid_Api.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ImdbMovieListViewModel> modell = new List<ImdbMovieListViewModel>(); 
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "001ad7d37amsh06db23fe33c506ap183c14jsnd358e7ee428f" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<ImdbMovieListViewModel>>(body);
                return View(model.ToList());


            }
        }
    }
}
