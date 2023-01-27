using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCommand;
using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Application.UnitTest.Mocks;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;

namespace GloboTicket.TicketManagement.Application.UnitTest.Categories.Commands
{
    public class CreateCategoryCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _repositoryMock;

        public CreateCategoryCommandHandlerTest()
        {
            _repositoryMock = RepositoryMocks.GetCategoryRepositoryMock();

            var configurationProvider = new MapperConfiguration(c =>
                c.AddProfile<MappingProfile>());

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task CreateCategory_AddCategory_If_NewCategoryIsValid()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _repositoryMock.Object);

            await handler.Handle(new CreateCategoryCommand() { Name = "Hello world" }, CancellationToken.None);

            var categories = await _repositoryMock.Object.ListAllAsync();

            categories.Count.ShouldBe(5);
        }
    }
}
