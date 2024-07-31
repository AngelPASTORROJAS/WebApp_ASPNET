using WebApp_ASPNET.ModelsDTO;

namespace WebApp_ASPNET.Interfaces
{
    public interface IContactService
    {
        IAsyncEnumerable<ContactDTO> GetAllAsync();
        Task<ContactDTO> GetByIdAsync(string id);
        Task CreateAsync(ContactDTO contact);
        Task UpdateAsync(ContactDTO contact);
        Task DeleteAsync(string id);
    }
}
