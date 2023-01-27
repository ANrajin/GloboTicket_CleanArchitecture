using GloboTicket.TicketManagement.Api.IntegrationTest.Base;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text.Json;

namespace GloboTicket.TicketManagement.Api.IntegrationTest.Controllers.Categories
{
    public class CategoriesControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public CategoriesControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetCategoryList_ResultSuccess()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("api/categories/index");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<CategoryListVm>>(responseString);

            Assert.IsType<List<CategoryListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}
