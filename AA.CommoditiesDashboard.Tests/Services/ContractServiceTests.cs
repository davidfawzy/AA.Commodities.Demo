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
    public class ContractServiceTests
    {
        private Mock<IContractRepository> _contractRepository;
        private Mock<IMapper> _mappper;

        private ContractService _contractService;

        [SetUp]
        public void SetUp()
        {
            _contractRepository = new Mock<IContractRepository>();
            _mappper = new Mock<IMapper>();
            _contractService = new ContractService(_contractRepository.Object, _mappper.Object);
            AutoMpperSetUp();
        }

        [Test]
        public async Task WhenICall_GetAllAsync_ShouldReturn_Valid_Data_Contracts()
        {
            var data = GetContractData(10);

            _contractRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Contract, bool>>>(), It.IsAny<Func<IQueryable<Contract>, IOrderedQueryable<Contract>>>(), It.IsAny<string>())).ReturnsAsync(data);

            var result = await _contractService.GetAllAsync();

           Assert.NotNull(result);

            _contractRepository.Verify(x => x.GetAsync(It.IsAny<Expression<Func<Contract, bool>>>(), It.IsAny<Func<IQueryable<Contract>, IOrderedQueryable<Contract>>>(), It.IsAny<string>()), Times.Once);
        }


        [Test]
        public void WhenICall_GetAllAsync_ShouldthrowException_InValid_Data_Contracts()
        {
            _contractRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Contract, bool>>>(), It.IsAny<Func<IQueryable<Contract>, IOrderedQueryable<Contract>>>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await _contractService.GetAllAsync());
        }
        #region Arrange Data

        private List<Contract> GetContractData(int numOfItems)
        {
            var model = new List<Contract>();
            for (var i = 0; i < numOfItems; i++)
            {
                model.Add(new Contract
                {
                    Name = $"Position{i}",
                });
            }
            return model;
        }

        private void AutoMpperSetUp()
        {
            _mappper.Setup(x => x.Map<List<ContractDto>>(It.IsAny<List<Contract>>())).Returns(new List<ContractDto> { });
        }

        #endregion
    }
}
