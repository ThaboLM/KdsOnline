using KdsOnline.Application.Exceptions;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using KdsOnline.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.Addresses.Queries
{
    public class GetAddressByIdQuery : IRequest<Response<Address>>
    {
        public int Id { get; set; }

        public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, Response<Address>>
        {
            private readonly IAddressRepositoryAsync _addressRepositoryAsync;

            public GetAddressByIdQueryHandler(IAddressRepositoryAsync addressRepositoryAsync)
            {
                _addressRepositoryAsync = addressRepositoryAsync;
            }

            public async Task<Response<Address>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
            {
                var address = await _addressRepositoryAsync.GetByIdAsync(request.Id);
                if (address == null) throw new ApiException($"Address not found.");
                return new Response<Address>(address);
            }
        }
    }
}
