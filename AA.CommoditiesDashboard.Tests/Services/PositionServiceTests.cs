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
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Tests.Services
{
    [TestFixture]
    class PositionServiceTests
    {
        private Mock<IPositionRepository> _positionRepository;
        private Mock<IMapper> _mappper;

        private PositionService _positionService;

        [SetUp]
        public void SetUp()
        {
            _positionRepository = new Mock<IPositionRepository>();
            _mappper = new Mock<IMapper>();
            _positionService = new PositionService(_positionRepository.Object, _mappper.Object);
            AutoMpperSetUp();
        }

        [Test]
        public async Task WhenICall_GetAllAsync_ShouldReturn_Valid_Data__Position()
        {
            var data = GetPositionData(10);

            _positionRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Position, bool>>>(), It.IsAny<Func<IQueryable<Position>, IOrderedQueryable<Position>>>(), It.IsAny<string>())).ReturnsAsync(data);

            var result = await _positionService.GetAllAsync();

            Assert.NotNull(result);

            _positionRepository.Verify(x => x.GetAsync(It.IsAny<Expression<Func<Position, bool>>>(), It.IsAny<Func<IQueryable<Position>, IOrderedQueryable<Position>>>(), It.IsAny<string>()), Times.Once);
        }


        [Test]
        public void WhenICall_GetAllAsync_ShouldthrowException_InValid_Data_Position()
        {
            _positionRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Position, bool>>>(), It.IsAny<Func<IQueryable<Position>, IOrderedQueryable<Position>>>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await _positionService.GetAllAsync());
        }


        #region Arrange Data

        private List<Position> GetPositionData(int numOfItems)
        {
            var model = new List<Position>();
            for (var i = 0; i < numOfItems; i++)
            {
                model.Add(new Position
                {
                    Name = $"Position{i}",
                });
            }
            return model;
        }

        private void AutoMpperSetUp()
        {
            _mappper.Setup(x => x.Map<List<PositionDto>>(It.IsAny<List<Position>>())).Returns(new List<PositionDto> { });
        }

        #endregion
    }
}
