using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Nash.Domain.Data;
using Nash.Domain.HubConfiguration;
using Nash.Domain.Services;
using Nash.Domain.Services.imp;
using System.Threading.Tasks;

namespace Nash_BackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    [DisableCors]
    public class ChartController : ControllerBase
    {
        private IHubContext<ChartHub> _hub;
        private IExchangerService exchangerService;

        public ChartController(IHubContext<ChartHub> hub, IExchangerService exchangerService)
        {
            _hub = hub;
            this.exchangerService = exchangerService;
        }

        
        public async Task<IActionResult> Get()
        {
            var result = await this.exchangerService.GetChartCurrencies();
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", result));

            return Ok(new { Message = "Request Completed" });
        }
    }
}
