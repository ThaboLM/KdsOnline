using AutoMapper;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.Addresses.Queries
{
    public class GetAllAddressesQuery : IRequest<PagedResponse<IEnumerable<GetAllAddressViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, PagedResponse<IEnumerable<GetAllAddressViewModel>>>
        {
            private readonly IAddressRepositoryAsync _addressRepositoryAsync;
            private readonly IMapper _mapper;

            public GetAllAddressesQueryHandler(IAddressRepositoryAsync addressRepositoryAsync, IMapper mapper)
            {
                _addressRepositoryAsync = addressRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<PagedResponse<IEnumerable<GetAllAddressViewModel>>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
            {
                var validFilters = _mapper.Map<GetAllAddressesParameter>(request);
                var address = await _addressRepositoryAsync.GetPagedReponseAsync(validFilters.PageNumber, validFilters.PageSize);
                var addressViewModel = _mapper.Map<IEnumerable<GetAllAddressViewModel>>(address);
                return new PagedResponse<IEnumerable<GetAllAddressViewModel>>(addressViewModel, validFilters.PageNumber, validFilters.PageSize);
            }
        }
    }
}
