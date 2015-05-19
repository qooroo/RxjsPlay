namespace RxjsPlay.Web.EventStream
{
    public class EventPump : IEventPump
    {
        public string Ping()
        {
            return "pong";
        }
    }
}