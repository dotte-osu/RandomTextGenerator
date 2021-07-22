using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace RandomTextGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextGenerator : ControllerBase
    {
        private readonly ILogger<TextGenerator> _logger;

        public TextGenerator(ILogger<TextGenerator> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<RandomTextGenerator> Get()
        {
            var data = new RandomTextGenerator()
            {
                Content = GetWikiSummary()
            };

            return data;
        }

        public static string GetWikiSummary()
        {
            var result = GetGameData().Result;
            var json = JObject.Parse(result);
            var summary = json["extract"].ToString();
            return summary;
        }

        private static async Task<string> GetGameData()
        {
            var url = "https://en.wikipedia.org/api/rest_v1/page/random/summary";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string strResult = await response.Content.ReadAsStringAsync();

                    return strResult;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
