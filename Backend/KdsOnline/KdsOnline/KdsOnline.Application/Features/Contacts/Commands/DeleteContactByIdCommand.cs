using KdsOnline.Application.Exceptions;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.Contacts.Commands
{
    public class DeleteContactByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteContactByIdCommandHandler : IRequestHandler<DeleteContactByIdCommand, Response<int>>
        {
            private readonly IContactRepositoryAsync _contactRepositoryAsync;

            public DeleteContactByIdCommandHandler(IContactRepositoryAsync contactRepositoryAsync)
            {
                _contactRepositoryAsync = contactRepositoryAsync;
            }

            public async Task<Response<int>> Handle(DeleteContactByIdCommand request, CancellationToken cancellationToken)
            {
                var contact = await _contactRepositoryAsync.GetByIdAsync(request.Id);
                if (contact == null) throw new ApiException($"Contact not found.");
                await _contactRepositoryAsync.DeleteAsync(contact);
                return new Response<int>(contact.Id);
            }
        }
    }
}
