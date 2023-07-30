using Microsoft.AspNetCore.Mvc;

namespace Casgem_Rapid_Api.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public async Task <IActionResult> Index(string adult, string child, string checkindate, string cheackoutdate, string roomnumber,string cityId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number={adult}&checkin_date={checkindate}&filter_by_currency=USD&dest_id={cityId}&locale=en-gb&checkout_date={cheackoutdate}&units=metric&room_number={roomnumber}&dest_type=city&include_adjacency=true&children_number={child}&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
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
                Console.WriteLine(body);
            }

            return View();
        }
    }
}
