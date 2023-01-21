namespace GloboTicket.TicketManagement.Application.Exceptions
{
    internal class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string name, object key)
            : base($"{name} ({key}) is not found!")
        {
        }
    }
}
