using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface IOrderRepository: IAsyncRepository<Order>
    {
        Task<List<Order>> GetPagedOrdersForMonth(DateTime requestDate, int requestPage, int requestSize);
        Task<int> GetTotalCountOfOrdersForMonth(DateTime requestDate);
    }
}
