using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Interfaces;
using WebApplication1.Models.Dtos.Club;
using Xunit;
using WebApplication1.TestingService.FakeData;
using System;

namespace TestingService
{
    [Trait("Category", "# Player Controller")]
    public class ClubControllerTest
    {
        private readonly Mock<IClubServices> mockClubManager;
        protected Mock<IMapper> MockMapper { get; }
        private readonly ClubController controller;
        private readonly ClubData clubData;

        public ClubControllerTest()
        {
            mockClubManager = new Mock<IClubServices>();
            MockMapper = new Mock<IMapper>();
            clubData = new ClubData();
            controller = new ClubController(
                                mockClubManager.Object,
                                MockMapper.Object);
        }

        [Trait("Category", "Get")]
        [Fact]
        //[FactName("Player Controller/Get -> players")]
        internal async Task GivenGetCalledWhenDataExistThenReturnsData()
        {
            // Arrange
            var clubs = clubData.FakeClubs();
            var clubGets = clubData.FakeClubGets();
            mockClubManager.
                Setup(_ => _.GetAsync())
                .ReturnsAsync(clubs);
            MockMapper
              .Setup(_ => _.Map<List<ClubGet>>(clubs))
              .Returns(clubGets);

            // Act
            var response = await controller.Get();

            // Assert
            mockClubManager.Verify(_ => _.GetAsync(), Times.Once);
            MockMapper.Verify(_ => _.Map<List<ClubGet>>(clubs), Times.Once());
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.Same(clubGets, result.Value);
            Assert.True(result.StatusCode == 200);
        }

        [Trait("Category", "Get")]
        [Fact]
        internal async Task GivenGetCalledWhenNoDataExistThenReturnsNoData()
        {
            // Arrange
            var clubs = clubData.FakeEmptyClubs();
            var clubGets = clubData.FakeEmptyClubGets();
            mockClubManager.
                Setup(_ => _.GetAsync())
                .ReturnsAsync(clubs);
            MockMapper
              .Setup(_ => _.Map<List<ClubGet>>(clubs))
              .Returns(clubGets);

            // Act
            var response = await controller.Get();

            // Assert
            mockClubManager.Verify(_ => _.GetAsync(), Times.Once);
            MockMapper.Verify(_ => _.Map<List<ClubGet>>(clubs), Times.Never());
            var result = Assert.IsType<NotFoundResult>(response);
            Assert.True(result.StatusCode == 404);
        }

        [Trait("Category", "Get")]
        [Fact]
        internal async Task GivenGetCalledWhenExceptionThrownThenHandlesGracefully()
        {
            // Arrange
            mockClubManager.
                Setup(_ => _.GetAsync())
                .Throws<Exception>();

            // Act
            var response = await controller.Get();

            // Assert
            mockClubManager.Verify(_ => _.GetAsync(), Times.Once);
            var result = Assert.IsType<BadRequestObjectResult>(response);
            Assert.True(result.StatusCode == 400);
        }

        [Trait("Category", "Create")]
        [Fact]
        internal async Task GivenCreateCalledWhenInputIsValidThenCreatesOneClub()
        {
            // Arrange
            var club = clubData.FakeClub();
            var clubPost = clubData.FakeClubPost();
            mockClubManager
                .Setup(_ => _.CreateAsync(club))
                .ReturnsAsync(club);
            MockMapper
              .Setup(_ => _.Map<ClubPost>(club))
              .Returns(clubPost);

            // Act
            var response = await controller.Create(club);

            // Assert
            mockClubManager.Verify(_ => _.CreateAsync(club), Times.Once);
            MockMapper.Verify(_ => _.Map<ClubPost>(club), Times.Once());
            var result = Assert.IsType<OkObjectResult>(response);

            Assert.True(result.StatusCode == 200);
        }

        [Trait("Category", "Create")]
        [Fact]
        internal async Task GivenCreateCalledWhenExceptionThrownThenHandlesGracefully()
        {
            // Arrange
            var club = clubData.FakeClub();
            var clubPost = clubData.FakeClubPost();
            mockClubManager
                .Setup(_ => _.CreateAsync(club))
                .Throws<Exception>();
            // Act
            var response = await controller.Create(club);

            // Assert
            mockClubManager.Verify(_ => _.CreateAsync(club), Times.Once);
            var result = Assert.IsType<BadRequestObjectResult>(response);

            Assert.True(result.StatusCode == 400);
        }

        [Trait("Category", "Delete")]
        [Fact]
        internal async Task GivenDeleteCalledWhenDataExistsThenDeletesClub()
        {
            var ids = clubData.FakeGuids();
            mockClubManager
                .Setup(_ => _.DeleteAsync(ids))
                .ReturnsAsync(true);

            // Act
            var response = await controller.DeleteAsync(ids);

            // Assert
            mockClubManager.Verify(_ => _.DeleteAsync(ids), Times.Once);

            var result = Assert.IsType<OkResult>(response);

            Assert.True(result.StatusCode == 200);
        }

        [Trait("Category", "Delete")]
        [Fact]
        internal async Task GivenDeleteCalledWhenNoDataExistsThenDeletesNoClub()
        {
            // Arrange
            var ids = clubData.FakeGuids();
            mockClubManager
                .Setup(_ => _.DeleteAsync(ids))
                .ReturnsAsync(false);

            // Act
            var response = await controller.DeleteAsync(ids);

            // Assert
            mockClubManager.Verify(_ => _.DeleteAsync(ids), Times.Once);

            var result = Assert.IsType<NotFoundResult>(response);

            Assert.True(result.StatusCode == 404);
        }

        [Trait("Category", "Delete")]
        [Fact]
        internal async Task GivenDeleteCalledWhenExceptionThrownThenHandlesGracefully()
        {
            // Arrange
            var ids = clubData.FakeGuids();
            mockClubManager
                .Setup(_ => _.DeleteAsync(ids))
                .Throws<Exception>();

            // Act
            var response = await controller.DeleteAsync(ids);

            // Assert
            mockClubManager.Verify(_ => _.DeleteAsync(ids), Times.Once);

            var result = Assert.IsType<BadRequestObjectResult>(response);
            Assert.True(result.StatusCode == 400);
        }
    }
}
