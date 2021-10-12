using KdsOnline.Application.Exceptions;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using KdsOnline.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.PersonalDetails.Commands
{
    public class UpdatePersonalDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string Nationality { get; set; }
        public virtual long ContactId { get; set; }

        public class UpdatePersonalDetailCommandHandler : IRequestHandler<UpdatePersonalDetailCommand, Response<int>>
        {
            private readonly IPersonalDetailRepositoryAsync _personalDetailRepositoryAsync;

            public UpdatePersonalDetailCommandHandler(IPersonalDetailRepositoryAsync personalDetailRepositoryAsync)
            {
                _personalDetailRepositoryAsync = personalDetailRepositoryAsync;
            }

            public async Task<Response<int>> Handle(UpdatePersonalDetailCommand request, CancellationToken cancellationToken)
            {
                var personalDetail = await _personalDetailRepositoryAsync.GetByIdAsync(request.Id);

                if(personalDetail == null)
                {
                    throw new ApiException($"Personal Detail not found.");
                }
                else
                {
                    personalDetail.FirstName = request.FirstName;
                    personalDetail.SecondName = request.SecondName;
                    personalDetail.Surname = request.Surname;
                    personalDetail.Gender = request.Gender;
                    personalDetail.DateOfBirth = request.DateOfBirth;
                    personalDetail.IdNumber = request.IdNumber;
                    personalDetail.Nationality = request.Nationality;
                    personalDetail.ContactId = request.ContactId;

                    await _personalDetailRepositoryAsync.UpdateAsync(personalDetail);
                    return new Response<int>(personalDetail.Id);
                }
            }
        }
    }   
}
