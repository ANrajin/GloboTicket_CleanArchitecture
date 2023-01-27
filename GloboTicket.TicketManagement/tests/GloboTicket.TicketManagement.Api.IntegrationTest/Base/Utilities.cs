using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Persistence.Contexts;

namespace GloboTicket.TicketManagement.Api.IntegrationTest.Base
{
    public class Utilities
    {
        public static void GetCategories(GloboTicketDbContext dbContext)
        {
            dbContext.Categories.Add(new Category
            {
                CategoryId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                Name = "Concerts"
            });

            dbContext.Categories.Add(new Category
            {
                CategoryId = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}"),
                Name = "Musicals"
            });

            dbContext.Categories.Add(new Category
            {
                CategoryId = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}"),
                Name = "Plays"
            });

            dbContext.Categories.Add(new Category
            {
                CategoryId = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}"),
                Name = "Conferences"
            });

            dbContext.SaveChangesAsync();
        }
    }
}
