using KdsOnline.Application.Exceptions;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using KdsOnline.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.Contacts.Queries
{
    public class GetContactByIdQuery : IRequest<Response<Contact>>
    {
        public int Id { get; set; }

        public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Response<Contact>>
        {
            private readonly IContactRepositoryAsync _contactRepositoryAsync;

            public GetContactByIdQueryHandler(IContactRepositoryAsync contactRepositoryAsync)
            {
                _contactRepositoryAsync = contactRepositoryAsync;
            }

            public async Task<Response<Contact>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
            {
                var contact = await _contactRepositoryAsync.GetByIdAsync(request.Id);
                if (contact == null) throw new ApiException($"Contact not found.");
                return new Response<Contact>(contact);
            }
        }
    }
}
