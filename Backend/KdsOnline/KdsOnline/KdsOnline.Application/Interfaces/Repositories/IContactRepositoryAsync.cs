using KdsOnline.Domain.Entities;
using System.Threading.Tasks;

namespace KdsOnline.Application.Interfaces.Repositories
{
    public interface IContactRepositoryAsync : IGenericRepositoryAsync<Contact>
    {
        Task<bool> IsEmailUnique(string email);
        Task<bool> IsMobileNumberUnique(string mobileNumber);
    }
}
