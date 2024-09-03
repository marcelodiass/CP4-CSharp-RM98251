using CP4_RM98251.Interfaces;
using CP4_RM98251.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CP4_RM98251.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : Controller, IExchangeController
    {
        // Este método retornará uma taxa de câmbio fictícia como um exemplo
        [HttpGet]
        public JsonResult GetExchangeRate()
        {
            try
            {
                String URLString = "https://v6.exchangerate-api.com/v6/94d8cb1d97e6ce14ed0cb352/pair/USD/BRL";
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    ExchangeResponse response = JsonConvert.DeserializeObject<ExchangeResponse>(json);

                    var exchangeRate = new
                    {
                        CurrencyPair = "USD/BRL",
                        Rate = response.conversion_rate,
                        Date = DateTime.Now
                    };

                    return Json(exchangeRate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Json(null);
            } 

        
        }
    }
}
