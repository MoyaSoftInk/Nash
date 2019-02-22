using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Nash.Domain.Data;
using Nash.Domain.HubConfiguration;
using Nash.Domain.Services;
using Nash.Domain.Services.imp;


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

        
        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));

            return Ok(new { Message = "Request Completed" });
        }
    }
}
