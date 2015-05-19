using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNet.SignalR;

namespace RxjsPlay.Web.Hubs
{
    public class BroadcastHub : Hub
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override Task OnConnected()
        {
            Log.InfoFormat("Client connected: {0}", Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            Log.InfoFormat("Client reconnected: {0}", Context.ConnectionId);
            return base.OnReconnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Log.InfoFormat("Client disconnected: {0}", Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
}