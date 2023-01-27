using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Common;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Contexts
{
    public class GloboTicketDbContext : DbContext, IGloboTicketDbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options)
            : base(options)
        {
        }

        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options,
            ILoggedInUserService loggedInUserService) : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(CategorySeed.Categories);
            modelBuilder.Entity<Event>().HasData(EventSeed.Events);
            modelBuilder.Entity<Order>().HasData(OrderSeed.Orders);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
