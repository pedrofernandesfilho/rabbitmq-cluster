using FluentAssertions;
using Microsoft.AspNetCore.Http;
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

            var result = (ObjectResult)controller.Post();

            result.StatusCode.Should().Be(StatusCodes.Status202Accepted);
        }
    }
}
