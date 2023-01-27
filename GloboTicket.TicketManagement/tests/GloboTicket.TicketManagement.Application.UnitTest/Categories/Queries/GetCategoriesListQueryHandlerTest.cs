using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Application.UnitTest.Mocks;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;

namespace GloboTicket.TicketManagement.Application.UnitTest.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _repositoryMock;

        public GetCategoriesListQueryHandlerTest()
        {
            _repositoryMock = RepositoryMocks.GetCategoryRepositoryMock();

            var configurationProvider = new MapperConfiguration(c => c
                .AddProfile<MappingProfile>());

            _mapper = configurationProvider.CreateMapper();
        }


        [Fact]
        public async Task GetCategoriesTest()
        {
            var handler = new GetCategoriesListQueryHandler(_repositoryMock.Object, _mapper);

            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListVm>>();

            result.Count.ShouldBe(4);
        }
    }
}
