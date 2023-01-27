using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;

namespace GloboTicket.TicketManagement.Application.UnitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Category>> GetCategoryRepositoryMock()
        {
            var categories = new List<Category>()
            {
                new Category
                {
                    CategoryId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                    Name = "Concerts"
                },
                new Category
                {
                    CategoryId = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}"),
                    Name = "Musicals"
                },
                new Category
                {
                    CategoryId = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}"),
                    Name = "Plays"
                },
                new Category
                {
                    CategoryId = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}"),
                    Name = "Conferences"
                }
            };

            var mockCategoryRepository = new Mock<IAsyncRepository<Category>>();

            mockCategoryRepository.Setup(x => x.ListAllAsync()).ReturnsAsync(categories);
            mockCategoryRepository.Setup(x => x.AddAsync(It.IsAny<Category>()))
                .ReturnsAsync((Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            return mockCategoryRepository;
        }
    }
}
