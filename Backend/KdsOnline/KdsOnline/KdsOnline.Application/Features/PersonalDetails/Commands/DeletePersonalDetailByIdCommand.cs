using KdsOnline.Application.Exceptions;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.PersonalDetails.Commands
{
    public class DeletePersonalDetailByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeletePersonalDetailByIdCommandHandler : IRequestHandler<DeletePersonalDetailByIdCommand, Response<int>>
        {
            public IPersonalDetailRepositoryAsync _personalDetailRepositoryAsync { get; set; }

            public DeletePersonalDetailByIdCommandHandler(IPersonalDetailRepositoryAsync personalDetailRepositoryAsync)
            {
                _personalDetailRepositoryAsync = personalDetailRepositoryAsync;
            }

            public async Task<Response<int>> Handle(DeletePersonalDetailByIdCommand request, CancellationToken cancellationToken)
            {
                var personalDetail = await _personalDetailRepositoryAsync.GetByIdAsync(request.Id);
                if (personalDetail == null) throw new ApiException($"Personal Detail not found.");
                await _personalDetailRepositoryAsync.DeleteAsync(personalDetail);
                return new Response<int>(personalDetail.Id);
            }
        }
    }
}
