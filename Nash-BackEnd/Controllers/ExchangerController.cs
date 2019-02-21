namespace Nash_BackEnd.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Nash.Domain.Enums;
    using Nash.Domain.Responses;
    using Nash.Domain.Services;
    using System;
    using System.Threading.Tasks;

    public class ExchangerController : Controller
    {
        private readonly IExchangerService exchangerService;

        public ExchangerController(IExchangerService exchangerService)
        {
            this.exchangerService = exchangerService;
        }

        /// <summary>
        /// Quote USD
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("cotizacion/dolar")]
        [Route("cotizacion/real")]
        [Route("cotizacion/euro")]
        public async Task<IActionResult> GetCunrrencyUSDAsync()
        {
            try
            {
                NashResponse nashResponse = new NashResponse();
                var currency = this.HttpContext.Request.Path.Value.ToString().Split("/")[2];

                if (currency.ToLower().Equals(CurrenciesNameEnum.dolar.ToString("g")))
                {
                    nashResponse = await this.exchangerService.GetQuote(CurrenciesNameEnum.dolar, CurrenciesCodeEnum.USD);
                }
                else if (currency.ToLower().Equals(CurrenciesNameEnum.euro.ToString("g")))
                {
                    nashResponse = await this.exchangerService.GetQuote(CurrenciesNameEnum.euro, CurrenciesCodeEnum.EUR);
                }
                else
                {
                    nashResponse = await this.exchangerService.GetQuote(CurrenciesNameEnum.real, CurrenciesCodeEnum.BRL);
                }

                return Ok(nashResponse);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return BadRequest(ModelState);
            }
        }

        ///// <summary>
        ///// Quote BRL
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("cotizacion/")]
        //public IActionResult GetCunrrencyBRL()
        //{

        //    return Ok();
        //}

        //[HttpGet]
        //[Route("cotizacion/dolar")]
        //public IActionResult GetCunrrency()
        //{

        //    return Ok();
        //}
    }
}
