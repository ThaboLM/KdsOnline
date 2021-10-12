using AutoMapper;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.Contacts.Queries
{
    public class GetAllContactsQuery : IRequest<PagedResponse<IEnumerable<GetAllContactsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, PagedResponse<IEnumerable<GetAllContactsViewModel>>>
        {
            private readonly IContactRepositoryAsync _contactRepositoryAsync;
            private readonly IMapper _mapper;

            public GetAllContactsQueryHandler(IContactRepositoryAsync contactRepositoryAsync, IMapper mapper)
            {
                _contactRepositoryAsync = contactRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<PagedResponse<IEnumerable<GetAllContactsViewModel>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
            {
                var validFilters = _mapper.Map<GetAllContactsParameter>(request);
                var contact = await _contactRepositoryAsync.GetPagedReponseAsync(validFilters.PageNumber, validFilters.PageSize);
                var contactViewModel = _mapper.Map<IEnumerable<GetAllContactsViewModel>>(contact);
                return new PagedResponse<IEnumerable<GetAllContactsViewModel>>(contactViewModel, validFilters.PageNumber, validFilters.PageSize);
            }
        }
    }
}
