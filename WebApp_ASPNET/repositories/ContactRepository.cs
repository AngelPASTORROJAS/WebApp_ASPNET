using WebApp_ASPNET.Interfaces;

namespace WebApp_ASPNET.repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async IAsyncEnumerable<Contact> GetAllAsync()
        {
            await foreach (var contact in _context.Contacts)
            {
                yield return contact;
            }
        }

        public async Task<Contact> GetByIdAsync(string id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task CreateAsync(Contact contact)
        {
            _context.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact contact)
        {
            _context.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ContactExists(string id) // si on fait getbyId on peut avoir a utiliser un trycatch soit plus lent
        {
            return await _context.Contacts.AnyAsync(e => e.Fullname == id);
        }
    }
}
