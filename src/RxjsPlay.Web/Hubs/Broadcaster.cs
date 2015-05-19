using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace RxjsPlay.Web.Hubs
{
    public class Broadcaster : IBroadcaster
    {
        private readonly IHubContext _context;

        public Broadcaster(IConnectionManager connectionManager)
        {
            _context = connectionManager.GetHubContext<BroadcastHub>();
        }

        public void BroadcastMessage(string message)
        {
            _context.Clients.All.OnMessage(message);
        }
    }
}