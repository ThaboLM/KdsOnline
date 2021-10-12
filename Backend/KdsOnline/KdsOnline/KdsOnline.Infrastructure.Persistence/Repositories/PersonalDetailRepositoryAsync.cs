using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Domain.Entities;
using KdsOnline.Infrastructure.Persistence.Contexts;
using KdsOnline.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdsOnline.Infrastructure.Persistence.Repositories
{
    public class PersonalDetailRepositoryAsync : GenericRepositoryAsync<PersonalDetail>, IPersonalDetailRepositoryAsync
    {
        private readonly DbSet<PersonalDetail> _personalDetail;

        public PersonalDetailRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _personalDetail = dbContext.Set<PersonalDetail>();
        }

        public Task<bool> IsUniqueIdNumberAsync(string idNumber)
        {
            return _personalDetail.AllAsync(pd => pd.IdNumber != idNumber);
        }
    }
}
