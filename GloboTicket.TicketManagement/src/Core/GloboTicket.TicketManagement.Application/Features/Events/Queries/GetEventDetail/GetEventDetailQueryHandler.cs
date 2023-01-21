using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Exceptions;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDeatilQuery, EventDetailVm>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetEventDetailQueryHandler(IAsyncRepository<Event> eventRepository, 
            IAsyncRepository<Category> categoryRepository, 
            IMapper mapper)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<EventDetailVm> Handle(GetEventDeatilQuery request, CancellationToken cancellationToken)
        {
            var @event = await GetEventDetailAsync(request.Id);
            var eventDetailDto = _mapper.Map<EventDetailVm>(@event);
            eventDetailDto.Category = await GetCategoryAsync(@event.CategoryId);

            return eventDetailDto;
        }

        private async Task<EventDetailVm> GetEventDetailAsync(Guid id)
        {
            var @event = await _eventRepository.GetByIdAsync(id);
            return _mapper.Map<EventDetailVm>(@event);
        }

        private async Task<CategoryDto> GetCategoryAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category is null)
                throw new ResourceNotFoundException(nameof(Event), id);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
