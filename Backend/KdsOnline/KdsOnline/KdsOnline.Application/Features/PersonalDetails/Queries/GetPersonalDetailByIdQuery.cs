using KdsOnline.Application.Exceptions;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using KdsOnline.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.PersonalDetails.Queries
{
    public class GetPersonalDetailByIdQuery : IRequest<Response<PersonalDetail>>
    {
        public int Id { get; set; }

        public class GetPersonalDetailByIdQueryHandler : IRequestHandler<GetPersonalDetailByIdQuery, Response<PersonalDetail>>
        {
            private readonly IPersonalDetailRepositoryAsync _personalDetailRepositoryAsync;

            public GetPersonalDetailByIdQueryHandler(IPersonalDetailRepositoryAsync personalDetailRepositoryAsync)
            {
                _personalDetailRepositoryAsync = personalDetailRepositoryAsync;
            }

            public async Task<Response<PersonalDetail>> Handle(GetPersonalDetailByIdQuery request, CancellationToken cancellationToken)
            {
                var personalDetail = await _personalDetailRepositoryAsync.GetByIdAsync(request.Id);
                if (personalDetail == null) throw new ApiException($"Personal Detail not found.");
                return new Response<PersonalDetail>(personalDetail);
            }
        }
    }

}
