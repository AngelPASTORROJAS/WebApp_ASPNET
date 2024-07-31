using Microsoft.AspNetCore.Mvc;
using WebApp_ASPNET.Interfaces;
using WebApp_ASPNET.ModelsDTO;

[ApiController]
[Route("[Controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    /// <summary>
    /// Récupère la liste de tous les contacts.
    /// </summary>
    /// <returns>La liste des contacts.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Index()
    {
        var contacts = _contactService.GetAllAsync();
        return Ok(contacts);
    }

    /// <summary>
    /// Récupère les détails d'un contact.
    /// </summary>
    /// <param name="id">L'identifiant du contact.</param>
    /// <returns>Les détails du contact.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Details(string id)
    {
        var contact = await _contactService.GetByIdAsync(id);
        if (contact == null)
        {
            return NotFound();
        }

        return Ok(contact);
    }

    /// <summary>
    /// Crée un nouveau contact.
    /// </summary>
    /// <param name="contact">Les informations du nouveau contact.</param>
    /// <returns>Le contact créé.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] ContactDTO contact) // TODO: vérifier si FK sexe existe, vérifier si fullname existe => renvoyer un action result
    {
        if (ModelState.IsValid)
        {
            await _contactService.CreateAsync(contact);
            return CreatedAtAction(nameof(Details), new { id = contact.Fullname }, contact);
        }

        return BadRequest(ModelState);
    }

    /// <summary>
    /// Modifie les informations d'un contact.
    /// </summary>
    /// <param name="id">L'identifiant du contact à modifier.</param>
    /// <param name="contact">Les nouvelles informations du contact.</param>
    /// <returns>Aucun contenu (204 No Content).</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Edit(string id, [FromBody] ContactDTO contact)
    {
        if (id != contact.Fullname)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _contactService.UpdateAsync(contact);
            }
            catch (Exception)
            {
                if (_contactService.GetByIdAsync(contact.Fullname) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        return BadRequest(ModelState);
    }

    /// <summary>
    /// Supprime un contact.
    /// </summary>
    /// <param name="id">L'identifiant du contact à supprimer.</param>
    /// <returns>Aucun contenu (204 No Content).</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(string id)
    {
        await _contactService.DeleteAsync(id);
        return NoContent();
    }
}