namespace WebApp_ASPNET.Interfaces
{
    public interface IContactRepository
    {
        IAsyncEnumerable<Contact> GetAllAsync();
        Task<Contact> GetByIdAsync(string id);
        Task CreateAsync(Contact contact);
        Task UpdateAsync(Contact contact);
        Task DeleteAsync(string id);
        Task<bool> ContactExists(string id);
    }
}
