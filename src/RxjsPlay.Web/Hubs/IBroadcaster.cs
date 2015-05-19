namespace RxjsPlay.Web.Hubs
{
    public interface IBroadcaster
    {
        void BroadcastMessage(string message);
    }
}