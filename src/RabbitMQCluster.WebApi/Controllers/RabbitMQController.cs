using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQCluster.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RabbitMQController : ControllerBase
    {
        private readonly ILogger<RabbitMQController> logger;
        private readonly IModel rabbitChannel;

        public RabbitMQController(
            ILogger<RabbitMQController> logger,
            IModel rabbitChannel)
        {
            this.logger = logger;
            this.rabbitChannel = rabbitChannel;
        }

        [HttpPost]
        public ActionResult Post()
        {
            const string queueName = "testQueue";

            rabbitChannel.QueueDeclare(queueName, exclusive: false);

            var message = Encoding.UTF8.GetBytes($"message: {DateTime.UtcNow}");
            rabbitChannel.BasicPublish("", queueName, body: message);

            logger.LogDebug("Queued message");
            return Accepted();
        }
    }
}
