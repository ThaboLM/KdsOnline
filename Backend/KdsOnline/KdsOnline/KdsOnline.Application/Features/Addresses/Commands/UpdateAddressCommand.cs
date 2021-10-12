using KdsOnline.Application.Exceptions;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.Addresses.Commands
{
    public class UpdateAddressCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public bool IsComplex { get; set; }
        public string ComplexName { get; set; }
        public int UnitNumber { get; set; }
        public string StreetAddress { get; set; }
        public int PostalCode { get; set; }

        public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, Response<int>>
        {
            private readonly IAddressRepositoryAsync _addressRepositoryAsync;

            public UpdateAddressCommandHandler(IAddressRepositoryAsync addressRepositoryAsync)
            {
                _addressRepositoryAsync = addressRepositoryAsync;
            }

            public async Task<Response<int>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
            {
                var address = await _addressRepositoryAsync.GetByIdAsync(request.Id);
                if (address == null)
                {
                    throw new ApiException($"Address not found.");
                }
                else
                {
                    address.Province = request.Province;
                    address.City = request.City;
                    address.Suburb = request.Suburb;
                    address.IsComplex = request.IsComplex;
                    address.ComplexName = request.ComplexName;
                    address.UnitNumber = request.UnitNumber;
                    address.StreetAddress = request.StreetAddress;
                    address.PostalCode = request.PostalCode;

                    await _addressRepositoryAsync.UpdateAsync(address);
                    return new Response<int>(address.Id);
                }
            }
        }
    }
}
