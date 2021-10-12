using KdsOnline.Application.Exceptions;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.Contacts.Commands
{
    public class UpdateContactCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string TelephoneNumber { get; set; }

        public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Response<int>>
        {
            private readonly IContactRepositoryAsync _contactRepositoryAsync;

            public UpdateContactCommandHandler(IContactRepositoryAsync contactRepositoryAsync)
            {
                _contactRepositoryAsync = contactRepositoryAsync;
            }

            public async Task<Response<int>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
            {
                var contact = await _contactRepositoryAsync.GetByIdAsync(request.Id);
                if(contact == null)
                {
                    throw new ApiException($"Contact not found.");
                }
                else
                {
                    contact.Email = request.Email;
                    contact.MobileNumber = request.MobileNumber;
                    contact.TelephoneNumber = request.TelephoneNumber;

                    await _contactRepositoryAsync.UpdateAsync(contact);
                    return new Response<int>(contact.Id);
                }
            }
        }
    }
}
