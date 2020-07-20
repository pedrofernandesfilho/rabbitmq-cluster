using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RabbitMQCluster.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RabbitMQController : ControllerBase
    {
        private readonly ILogger<RabbitMQController> logger;

        public RabbitMQController(ILogger<RabbitMQController> logger) =>
            this.logger = logger;

        [HttpPost]
        public ActionResult Post()
        {
            // TODO: Queue message
            logger.LogDebug("Queued message");
            return Accepted();
        }
    }
}
