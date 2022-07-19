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
    public class ModelResultServiceTests
    {
        private Mock<IModelResultRepository> _modelRepository;
        private Mock<IMapper> _mappper;

        private ModelResultService _modelService;

        [SetUp]
        public void SetUp()
        {
            _modelRepository = new Mock<IModelResultRepository>();
            _mappper = new Mock<IMapper>();
            _modelService = new ModelResultService(_modelRepository.Object, _mappper.Object);
            AutoMpperSetUp();
        }

        [Test]
        public async Task WhenICall_GetAllAsync_ShouldReturn_Valid_Data_ModelResult()
        {
            var data = GetModelResultData(10);

            _modelRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<ModelResult, bool>>>(), It.IsAny<Func<IQueryable<ModelResult>, IOrderedQueryable<ModelResult>>>(), It.IsAny<string>())).ReturnsAsync(data);

            var result = await _modelService.GetAllAsync();

            Assert.NotNull(result);

            _modelRepository.Verify(x => x.GetAsync(It.IsAny<Expression<Func<ModelResult, bool>>>(), It.IsAny<Func<IQueryable<ModelResult>, IOrderedQueryable<ModelResult>>>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void WhenICall_GetAllAsync_ShouldthrowException_InValid_Data_ModelResult()
        {
            _modelRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<ModelResult, bool>>>(), It.IsAny<Func<IQueryable<ModelResult>, IOrderedQueryable<ModelResult> >>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await _modelService.GetAllAsync());
        }


        #region Arrange Data

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
            _mappper.Setup(x => x.Map<List<ModelResultDto>>(It.IsAny<List<ModelResult>>())).Returns(new List<ModelResultDto> { });
        }

        #endregion
    }
}
