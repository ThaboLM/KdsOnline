using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.Addresses.Commands
{
    public class CreateAddressCommand : IRequest<Response<int>>
    {
        public string Province { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public bool IsComplex { get; set; }
        public string ComplexName { get; set; }
        public int UnitNumber { get; set; }
        public string StreetAddress { get; set; }
        public int PostalCode { get; set; }

        public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Response<int>>
        {
            private readonly IAddressRepositoryAsync _addressRepositoryAsync;

            public CreateAddressCommandHandler(IAddressRepositoryAsync addressRepositoryAsync)
            {
                _addressRepositoryAsync = addressRepositoryAsync;
            }

            public Task<Response<int>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
