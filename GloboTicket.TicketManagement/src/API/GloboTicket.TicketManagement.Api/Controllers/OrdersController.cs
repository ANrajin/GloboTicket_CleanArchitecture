using GloboTicket.TicketManagement.Application.Features.Orders.Queries.GetOrdersForMonth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/get-paged-orders-for-month", Name = "GetPagedOrdersForMonth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedOrdersForMonthVm>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            var getOrdersForMonthQuery = new GetOrdersForMonthQuery() { Date = date, Page = page, Size = size };

            var response = await _mediator.Send(getOrdersForMonthQuery);

            return Ok(response);
        }
    }
}
