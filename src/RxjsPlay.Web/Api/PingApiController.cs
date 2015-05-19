using System.Web.Http;
using RxjsPlay.Web.EventStream;

namespace RxjsPlay.Web.Api
{
    public class PingApiController : ApiController
    {
        private readonly IEventPump _eventPump;

        public PingApiController(IEventPump eventPump)
        {
            _eventPump = eventPump;
        }

        [HttpGet]
        [Route("ping")]
        public IHttpActionResult Ping()
        {
            return Ok(_eventPump.Ping());
        }
    }
}