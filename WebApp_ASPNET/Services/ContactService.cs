using WebApp_ASPNET.Interfaces;
using WebApp_ASPNET.ModelsDTO;

namespace WebApp_ASPNET.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async IAsyncEnumerable<ContactDTO> GetAllAsync()
        {
            await foreach (var contact in _contactRepository.GetAllAsync())
            {
                yield return contact;
            }
        }

        public async Task<ContactDTO> GetByIdAsync(string id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            if (contact == null) {
                return null;
            }
            return contact;
        }

        public async Task CreateAsync(ContactDTO contactDto)
        {
            await _contactRepository.CreateAsync(contactDto);
        }

        public async Task UpdateAsync(ContactDTO contactDto)
        {
            await _contactRepository.UpdateAsync(contactDto);
        }

        public async Task DeleteAsync(string id)
        {
            await _contactRepository.DeleteAsync(id);
        }
    }
}
