using GloboTicket.TicketManagement.Application.Response;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCommand
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base()
        {
        }

        public CreateCategoryDto Category { get; set; } = default!;
    }
}
