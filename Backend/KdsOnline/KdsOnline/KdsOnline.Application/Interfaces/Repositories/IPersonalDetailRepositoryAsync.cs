using KdsOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KdsOnline.Application.Interfaces.Repositories
{
    public interface IPersonalDetailRepositoryAsync : IGenericRepositoryAsync<PersonalDetail>
    {
        Task<bool> IsUniqueIdNumberAsync(string idNumber);
    }
}
