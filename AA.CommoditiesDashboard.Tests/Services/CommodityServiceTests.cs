using AutoMapper;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;
using AA.CommoditiesDashboard.Services;
using AA.CommoditiesDashboard.Services.Interfaces;
using AA.CommoditiesDashboard.Services.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Tests.Services
{
    [TestFixture]
    public class CommodityServiceTests
    {
        private Mock<ICommodityRepository> _commodityRepository;
        private Mock<IMapper> _mappper;

        private CommodityService _commodityService;

        [SetUp]
        public void SetUp()
        {
            _commodityRepository = new Mock<ICommodityRepository>();
            _mappper = new Mock<IMapper>();
            _commodityService = new CommodityService(_commodityRepository.Object, _mappper.Object);
            AutoMpperSetUp();
        }

        [Test]
        public async Task WhenICall_GetPnlYTDMtricAsync_ShouldReturn_Valid_Data_Commodities()
        {
            var data = GetCommodityData(10);

            _commodityRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Commodity, bool>>>(), It.IsAny<Func<IQueryable<Commodity>, IOrderedQueryable<Commodity>>>(), It.IsAny<string>())).ReturnsAsync(data);

            var result = await _commodityService.GetAllPnlYTDMetricAsync();

            Assert.NotNull(result);

            _commodityRepository.Verify(x => x.GetAsync(It.IsAny<Expression<Func<Commodity, bool>>>(), It.IsAny<Func<IQueryable<Commodity>, IOrderedQueryable<Commodity>>>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void WhenICall_GetPnlYTDMtricAsync_ShouldthrowException_InValid_Data_Commodities()
        {
            _commodityRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Commodity, bool>>>(), It.IsAny<Func<IQueryable<Commodity>, IOrderedQueryable<Commodity>>>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await _commodityService.GetAllPnlYTDMetricAsync());
        }

        [Test]
        public async Task WhenICall_GetPnlYTDMetricByIdAsync_ShouldReturn_Valid_Data_Commodities()
        {
            var data = GetCommodityData(1);

            _commodityRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Commodity, bool>>>(), It.IsAny<Func<IQueryable<Commodity>, IOrderedQueryable<Commodity>>>(), It.IsAny<string>())).ReturnsAsync(data);

            var result = await _commodityService.GetPnlYTDMetricByIdAsync(1);

            Assert.NotNull(result);

            _commodityRepository.Verify(x => x.GetAsync(It.IsAny<Expression<Func<Commodity, bool>>>(), It.IsAny<Func<IQueryable<Commodity>, IOrderedQueryable<Commodity>>>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void WhenICall_GetPnlYTDMetricByIdAsync_ShouldthrowException_InValid_Data_Commodities()
        {
            _commodityRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Commodity, bool>>>(), It.IsAny<Func<IQueryable<Commodity>, IOrderedQueryable<Commodity>>>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await _commodityService.GetPnlYTDMetricByIdAsync(1));
        }

        #region Arrange Data

        private List<Commodity> GetCommodityData(int numOfItems)
        {
            var model = new List<Commodity>();
            for (var i = 0; i < numOfItems; i++)
            {
                model.Add(new Commodity
                {
                    Name = $"Commodity{i}",
                    ModelResult = GetModelResultData(10)
                });
            }
            return model;
        }

        private List<ModelResult> GetModelResultData(int numOfItems)
        {
            var model = new List<ModelResult>();
            for (var i = 0; i < numOfItems; i++)
            {
                model.Add(new ModelResult
                {
                    Date = DateTime.UtcNow.AddDays(i),
                    PnlDaily = 4521 + i,
                    Price = 4251 + i,

                });
            }
            return model;
        }

        private void AutoMpperSetUp()
        {
            _mappper.Setup(x => x.Map<ModelResultDto>(It.IsAny<ModelResult>())).Returns(new ModelResultDto { });
        }

        #endregion
    }
}
