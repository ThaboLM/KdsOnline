using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Domain.Entities;
using KdsOnline.Infrastructure.Persistence.Contexts;
using KdsOnline.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace KdsOnline.Infrastructure.Persistence.Repositories
{
    public class AddressRepositoryAsync : GenericRepositoryAsync<Address>, IAddressRepositoryAsync
    {
        private readonly DbSet<Address> _address;
        public AddressRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _address = dbContext.Set<Address>();
        }
    }
}
