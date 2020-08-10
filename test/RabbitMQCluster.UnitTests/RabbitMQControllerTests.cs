using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using RabbitMQ.Client;
using RabbitMQCluster.WebApi.Controllers;
using System;

namespace RabbitMQCluster.UnitTests
{
    public class RabbitMQControllerPostTests
    {
        private ActionResult result;
        private Mock<IModel> rabbitChannelMock;

        [SetUp]
        public void PostRequest()
        {
            var logger = Mock.Of<ILogger<RabbitMQController>>();
            rabbitChannelMock = new Mock<IModel>();
            var controller = new RabbitMQController(logger, rabbitChannelMock.Object);

            result = controller.Post();
        }

        [Test]
        public void ShouldReturnAccepted() =>
            result.Should().BeOfType<AcceptedResult>();

        [Test]
        public void ShouldCallBasicPublish() =>
            rabbitChannelMock .Verify(c =>
                c.BasicPublish("", "testQueue", false, null, It.IsAny<ReadOnlyMemory<byte>>()), Times.Once);
    }
}
