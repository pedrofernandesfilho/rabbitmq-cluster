using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using RabbitMQCluster.WebApi.Controllers;

namespace RabbitMQCluster.UnitTests
{
    public class RabbitMQControllerTests
    {
        [Test]
        public void WhenPostShouldReturnAccepted()
        {
            var logger = Mock.Of<ILogger<RabbitMQController>>();
            var controller = new RabbitMQController(logger);

            var result = controller.Post();

            result.Should().BeOfType<AcceptedResult>();
        }
    }
}
