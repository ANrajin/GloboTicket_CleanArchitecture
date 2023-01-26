using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCommand;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoiesListWithEvents;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> Index()
        {
            var response = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(response);
        }

        [Authorize]
        [HttpGet("with-events", Name = "GetCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryEventListVm>>> GetCategoriesWithEvents(bool includeHistory)
        {
            var getCategoriesListWithEventsQuery = new GetCategoriesListWithEventQuery() { IncludeHistory = includeHistory };

            var response = await _mediator.Send(getCategoriesListWithEventsQuery);
            return Ok(response);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create(
            [FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}
