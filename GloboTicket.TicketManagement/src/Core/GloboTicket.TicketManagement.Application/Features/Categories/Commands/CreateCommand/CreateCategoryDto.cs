namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCommand
{
    public class CreateCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
