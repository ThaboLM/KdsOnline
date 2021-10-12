using AutoMapper;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using KdsOnline.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.Contacts.Commands
{
    public class CreateContactCommand : IRequest<Response<int>>
    {
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string TelephoneNumber { get; set; }

        public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Response<int>>
        {
            private readonly IContactRepositoryAsync _contactRepositoryAsync;
            private readonly IMapper _mapper;

            public CreateContactCommandHandler(IContactRepositoryAsync contactRepositoryAsync, IMapper mapper)
            {
                _contactRepositoryAsync = contactRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
            {
                var contact = _mapper.Map<Contact>(request);
                await _contactRepositoryAsync.AddAsync(contact);
                return new Response<int>(contact.Id);
            }
        }
    }
}
