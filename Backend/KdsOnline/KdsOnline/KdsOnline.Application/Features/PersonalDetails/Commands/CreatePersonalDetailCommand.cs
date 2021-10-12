using AutoMapper;
using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Application.Wrappers;
using KdsOnline.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.PersonalDetails
{
    public class CreatePersonalDetailCommand : IRequest<Response<int>>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string Nationality { get; set; }
        public virtual long ContactId { get; set; }

        public class CreatePersonaldetailCommandHanlder : IRequestHandler<CreatePersonalDetailCommand, Response<int>>
        {
            private readonly IPersonalDetailRepositoryAsync _personalDetailRepositoryAsync;
            private readonly IMapper _mapper;

            public CreatePersonaldetailCommandHanlder(IPersonalDetailRepositoryAsync personalDetailsRepositoryAsync, IMapper mapper)
            {
                _personalDetailRepositoryAsync = personalDetailsRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(CreatePersonalDetailCommand request, CancellationToken cancellationToken)
            {
                var personalDetail = _mapper.Map<PersonalDetail>(request);
                await _personalDetailRepositoryAsync.AddAsync(personalDetail);
                return new Response<int>(personalDetail.Id);
            }
        }
    }
}
