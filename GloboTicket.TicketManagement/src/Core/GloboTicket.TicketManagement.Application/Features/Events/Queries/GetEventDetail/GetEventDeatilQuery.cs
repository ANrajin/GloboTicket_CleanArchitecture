using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDeatilQuery : IRequest<EventDetailVm>
    {
        public Guid Id { get; set; }
    }
}
