using KdsOnline.Application.Exceptions;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.Addresses.Commands
{
    public class DeleteAddressByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteAddressByIdCommandHandler : IRequestHandler<DeleteAddressByIdCommand, Response<int>>
        {
            private readonly IAddressRepositoryAsync _addressRepositoryAsync;

            public DeleteAddressByIdCommandHandler(IAddressRepositoryAsync addressRepositoryAsync)
            {
                _addressRepositoryAsync = addressRepositoryAsync;
            }

            public async Task<Response<int>> Handle(DeleteAddressByIdCommand request, CancellationToken cancellationToken)
            {
                var address = await _addressRepositoryAsync.GetByIdAsync(request.Id);
                if (address == null) throw new ApiException($"Address not found.");
                await _addressRepositoryAsync.DeleteAsync(address);
                return new Response<int>(address.Id);
            }
        }
    }
}
