using KdsOnline.Application.Interfaces.Repositories;
using KdsOnline.Domain.Entities;
using KdsOnline.Infrastructure.Persistence.Contexts;
using KdsOnline.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KdsOnline.Infrastructure.Persistence.Repositories
{
    public class ContactRepositoryAsync : GenericRepositoryAsync<Contact>, IContactRepositoryAsync
    {
        private readonly DbSet<Contact> _contact;

        public ContactRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _contact = dbContext.Set<Contact>();
        }

        public Task<bool> IsEmailUnique(string email)
        {
            return _contact.AllAsync(c => c.Email != email);
        }

        public Task<bool> IsMobileNumberUnique(string mobileNumber)
        {
            return _contact.AllAsync(c => c.MobileNumber != mobileNumber);
        }
    }
}
