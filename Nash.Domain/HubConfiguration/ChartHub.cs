using Microsoft.AspNetCore.SignalR;
using Nash.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nash.Domain.HubConfiguration
{
    public class ChartHub : Hub
    {
        public async Task BroadcastChartData(List<ChartModel> data) => await Clients.All.SendAsync("broadcastchartdata", data);
    }
}
