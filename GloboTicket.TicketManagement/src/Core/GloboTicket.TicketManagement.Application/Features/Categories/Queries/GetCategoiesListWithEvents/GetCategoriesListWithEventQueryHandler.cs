using MediatR;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoiesListWithEvents
{
    public class GetCategoriesListWithEventQueryHandler : IRequestHandler<GetCategoriesListWithEventQuery, List<CategoryEventListVm>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListWithEventQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryEventListVm>> Handle(
            GetCategoriesListWithEventQuery request, 
            CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
            return _mapper.Map<List<CategoryEventListVm>>(result);
        }
    }
}
