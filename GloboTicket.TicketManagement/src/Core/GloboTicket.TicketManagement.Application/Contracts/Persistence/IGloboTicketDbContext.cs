using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface IGloboTicketDbContext : IDisposable
    {
        DbSet<Event> Events { get; }
        DbSet<Category> Categories { get; }
        DbSet<Order> Orders { get; }
    }
}
