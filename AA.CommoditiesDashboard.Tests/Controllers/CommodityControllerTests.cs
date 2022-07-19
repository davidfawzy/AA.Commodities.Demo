using AA.CommoditiesDashboard.Services.Interfaces;
using AA.CommoditiesDashboard.Services.Models;
using AA.CommoditiesDashboard.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Tests.Controllers
{
    [TestFixture]
    public class CommodityControllerTests
    {
        private CommodityController _controller;
        private Mock<ICommodityService> _service;
        private Mock<ILogger<CommodityController>> _logger;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<ICommodityService>();
            _logger = new Mock<ILogger<CommodityController>>();
            _controller = new CommodityController(_service.Object, _logger.Object);
        }

        [Test]
        public async Task WhenICall_Index_Should_Return_Ok()
        {
            _service.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<CommodityDto> { new CommodityDto { Id = 1, Name = "Commodity 1" } });

            var result = await _controller.Index();
            var okResult = result as OkObjectResult;

            _service.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.IsTrue(okResult.StatusCode == 200);
        }

        [Test]
        public async Task WhenICall_GetPnlYTDMetricAsync_Should_Return_Ok()
        {
            _service.Setup(x => x.GetAllPnlYTDMetricAsync()).ReturnsAsync(new List< HistoricalCommodityDto> { new  HistoricalCommodityDto { Id = 1, Metrics = new List<HistoricalPnlByYearsDto> { new HistoricalPnlByYearsDto { Year = 2022, CummulativePnl = 4500 } } } });

            var result = await _controller.GetPnlYTDMetricAsync();
            var okResult = result as OkObjectResult;

            _service.Verify(x => x.GetAllPnlYTDMetricAsync(), Times.Once);
            Assert.IsTrue(okResult.StatusCode == 200);
        }

        [Test]
        public async Task WhenICall_GetPnlYTDMetricAsyncById_Should_Return_Ok()
        {
            _service.Setup(x => x.GetPnlYTDMetricByIdAsync(It.IsAny<int>())).ReturnsAsync( new HistoricalCommodityDto { Id = 1, Metrics = new List< HistoricalPnlByYearsDto> { new  HistoricalPnlByYearsDto { Year = 2022, CummulativePnl = 4500 } } } );

            var result = await _controller.GetPnlYTDMetricAsync(1);
            var okResult = result as OkObjectResult;

            _service.Verify(x => x.GetPnlYTDMetricByIdAsync(It.IsAny<int>()), Times.Once);
            Assert.IsTrue(okResult.StatusCode == 200);
        }
    }
}
