using AutoMapper;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;
using AA.CommoditiesDashboard.Services;
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
    public class NewTradeActionServiceTests
    {
        private Mock<INewTradeActionRepository> _newTradeActionRepository;
        private Mock<IMapper> _mappper;

        private NewTradeActionService _newTradeActionService;

        [SetUp]
        public void SetUp()
        {
            _newTradeActionRepository = new Mock<INewTradeActionRepository>();
            _mappper = new Mock<IMapper>();
            _newTradeActionService = new NewTradeActionService(_newTradeActionRepository.Object, _mappper.Object);
            AutoMpperSetUp();
        }

        [Test]
        public async Task WhenICall_GetAllAsync_ShouldReturn_Valid_Data__Position()
        {
            var data = GetNewTradeActionData(10);

            _newTradeActionRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<NewTradeAction, bool>>>(), It.IsAny<Func<IQueryable<NewTradeAction>, IOrderedQueryable<NewTradeAction>>>(), It.IsAny<string>())).ReturnsAsync(data);

            var result = await _newTradeActionService.GetAllAsync();

            Assert.NotNull(result);

            _newTradeActionRepository.Verify(x => x.GetAsync(It.IsAny<Expression<Func<NewTradeAction, bool>>>(), It.IsAny<Func<IQueryable<NewTradeAction>, IOrderedQueryable<NewTradeAction>>>(), It.IsAny<string>()), Times.Once);
        }


        [Test]
        public void WhenICall_GetAllAsync_ShouldthrowException_InValid_Data_Position()
        {
            _newTradeActionRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<NewTradeAction, bool>>>(), It.IsAny<Func<IQueryable<NewTradeAction>, IOrderedQueryable<NewTradeAction>>>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await _newTradeActionService.GetAllAsync());
        }

        #region Arrange Data

        private List<NewTradeAction> GetNewTradeActionData(int numOfItems)
        {
            var model = new List<NewTradeAction>();
            for (var i = 0; i < numOfItems; i++)
            {
                model.Add(new NewTradeAction
                {
                    Name = $"Position{i}",
                });
            }
            return model;
        }

        private void AutoMpperSetUp()
        {
            _mappper.Setup(x => x.Map<List<NewTradeActionDto>>(It.IsAny<List<NewTradeAction>>())).Returns(new List<NewTradeActionDto> { });
        }

        #endregion
    }
}
