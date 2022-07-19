using AutoMapper;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;
using AA.CommoditiesDashboard.Services;
using AA.CommoditiesDashboard.Services.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Tests.Services
{
    [TestFixture]
    public class ModelServiceTests
    {
        private Mock<IModelRepository> _modelRepository;
        private Mock<IMapper> _mappper;

        private ModelService _modelService;

        [SetUp]
        public void SetUp()
        {
            _modelRepository = new Mock<IModelRepository>();
            _mappper = new Mock<IMapper>();
            _modelService = new ModelService(_modelRepository.Object, _mappper.Object);
            AutoMpperSetUp();
        }

        [Test]
        public async Task WhenICall_GetAllAsync_ShouldReturn_Valid_Data_Commodities()
        {
            var data = GetModelData(10);

            _modelRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Model, bool>>>(), It.IsAny<Func<IQueryable<Model>, IOrderedQueryable<Model>>>(), It.IsAny<string>())).ReturnsAsync(data);

            var result = await _modelService.GetAllAsync();

            Assert.NotNull(result);

            _modelRepository.Verify(x => x.GetAsync(It.IsAny<Expression<Func<Model, bool>>>(), It.IsAny<Func<IQueryable<Model>, IOrderedQueryable<Model>>>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void WhenICall_GetAllAsync_ShouldthrowException_InValid_Data_Commodities()
        {
            _modelRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Model, bool>>>(), It.IsAny<Func<IQueryable<Model>, IOrderedQueryable<Model>>>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await _modelService.GetAllAsync());
        }

        [Test]
        public async Task WhenICall_GetAllYearlyPnlPriceMetricsAsync_ShouldReturn_Valid_Data_Commodities()
        {
            var data = GetModelData(10);

            _modelRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Model, bool>>>(), It.IsAny<Func<IQueryable<Model>, IOrderedQueryable<Model>>>(), It.IsAny<string>())).ReturnsAsync(data);

            var result = await _modelService.GetAllYearlyPnlPriceMetricsAsync();

            Assert.NotNull(result);

           _modelRepository.Verify(x => x.GetAsync(It.IsAny<Expression<Func<Model, bool>>>(), It.IsAny<Func<IQueryable<Model>, IOrderedQueryable<Model>>>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void WhenICall_GetAllYearlyPnlPriceMetricsAsync_ShouldthrowException_InValid_Data_Commodities()
        {
            _modelRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Model, bool>>>(), It.IsAny<Func<IQueryable<Model>, IOrderedQueryable<Model>>>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await _modelService.GetAllYearlyPnlPriceMetricsAsync());
        }


        #region Arrange Data

        private List<Model> GetModelData(int numOfItems)
        {
            var model = new List<Model>();
            for (var i = 0; i < numOfItems; i++)
            {
                model.Add(new Model
                {
                    Name = $"Model{i}",
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
            _mappper.Setup(x => x.Map<ModelDto>(It.IsAny<Model>())).Returns(new ModelDto { });
            _mappper.Setup(x => x.Map<Model>(It.IsAny<ModelDto>())).Returns(new Model { });
            _mappper.Setup(x => x.Map<List<ModelDto>>(It.IsAny<List<Model>>())).Returns(new List<ModelDto> { });
        }

        #endregion
    }
}
