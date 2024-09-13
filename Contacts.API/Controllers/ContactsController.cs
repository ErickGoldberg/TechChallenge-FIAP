using Contacts.Domain.Entities;
using Contacts.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsController(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        /// <summary>
        /// Retorna todos os contatos.
        /// </summary>
        /// <returns>Status 200 OK se encontrado, ou 404 Not Found.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(List<Contact>))]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactsRepository.GetContactsAsync();
            return Ok(contacts); 
        }

        /// <summary>
        /// Retorna um contato específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do contato.</param>
        /// <returns>Status 200 OK se encontrado, ou 404 Not Found.</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Contact))]
        public async Task<IActionResult> GetById(Guid id)
        {
            var contact = _contactsRepository.GetContactByIdAsync(id);
            return Ok(contact); 
        }

        /// <summary>
        /// Insere um novo contato.
        /// </summary>
        /// <returns>Status 201 Created, ou 400 BadRequest.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert(Contact contact)
        {
            await _contactsRepository.CreateContactAsync(contact);
            return Created(); 
        }

        /// <summary>
        /// Atualiza um contato existente.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>Status 204 No Content, ou 404 Not Found.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Contact contact)
        {
            await _contactsRepository.UpdateContactAsync(contact);
            return NoContent(); 
        }

        /// <summary>
        /// Deleta um contato pelo ID.
        /// </summary>
        /// <param name="id">O ID do contato.</param>
        /// <returns>Status 204 No Content, ou 404 Not Found.</returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _contactsRepository.DeleteContactAsync(id);
            return NoContent(); 
        }
    }

}
