using AutoMapper;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.PersonalDetails.Queries
{
    public class GetAllPersonalDetailsQuery : IRequest<PagedResponse<IEnumerable<GetAllPersonalDetailsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public class GetAllPersonalDetailsQueryHandler : IRequestHandler<GetAllPersonalDetailsQuery, PagedResponse<IEnumerable<GetAllPersonalDetailsViewModel>>>
        {
            private readonly IPersonalDetailRepositoryAsync _personalDetailRepositoryAsync;
            private readonly IMapper _mapper;

            public GetAllPersonalDetailsQueryHandler(IPersonalDetailRepositoryAsync personalDetailRepositoryAsync, IMapper mapper)
            {
                _personalDetailRepositoryAsync = personalDetailRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<PagedResponse<IEnumerable<GetAllPersonalDetailsViewModel>>> Handle(GetAllPersonalDetailsQuery request, CancellationToken cancellationToken)
            {
                var validFilter = _mapper.Map<GetAllPersonalDetailsParameters>(request);
                var personalDetail = await _personalDetailRepositoryAsync.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
                var personalDetailViewModel = _mapper.Map<IEnumerable<GetAllPersonalDetailsViewModel>>(personalDetail);
                return new PagedResponse<IEnumerable<GetAllPersonalDetailsViewModel>>(personalDetailViewModel, validFilter.PageNumber, validFilter.PageSize);
            }
        }
    }
}
