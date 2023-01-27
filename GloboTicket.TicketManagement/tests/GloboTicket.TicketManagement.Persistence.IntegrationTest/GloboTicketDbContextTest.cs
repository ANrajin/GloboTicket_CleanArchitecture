using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace GloboTicket.TicketManagement.Persistence.IntegrationTest
{
    public class GloboTicketDbContextTest
    {
        private readonly GloboTicketDbContext _dbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _userId;

        public GloboTicketDbContextTest()
        {
            var _dbContextOption = new DbContextOptionsBuilder<GloboTicketDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _userId = Guid.NewGuid().ToString();
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(x => x.UserId).Returns(_userId);

            _dbContext = new GloboTicketDbContext(_dbContextOption, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async Task SetCreatedBy_OnSave()
        {
            var category = new Category()
            {
                CategoryId = Guid.NewGuid(),
                Name = "test category"
            };

            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            category.CreatedBy.ShouldBe(_userId);
        }
    }
}
