using Contacts.Domain.Entities;
using Contacts.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Contacts.Application.Services;
using Contacts.Application.Dtos;
using Contacts.Application.InputModels;

namespace Contacts.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactsService;

        public ContactsController(IContactService contactsRepository)
        {
            _contactsService = contactsRepository;
        }

        /// <summary>
        /// Retorna todos os contatos.
        /// </summary>
        /// <returns>Status 200 OK se encontrado, ou 404 Not Found.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(List<ContactDto>))]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactsService.GetContactsAsync();
            return Ok(contacts.Data);
        }

        /// <summary>
        /// Retorna um contato específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do contato.</param>
        /// <returns>Status 200 OK se encontrado, ou 404 Not Found.</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(ContactDto))]
        public async Task<IActionResult> GetById(Guid id)
        {
            var contact = await _contactsService.GetContactByIdAsync(id);

            if (contact.Data != null)
                return Ok(contact.Data);

            return NotFound();
        }

        /// <summary>
        /// Retorna um contato específico pelo DDD.
        /// </summary>
        /// <param name="ddd">O DDD do contato.</param>
        /// <returns>Status 200 OK se encontrado, ou 404 Not Found.</returns>
        [HttpGet("{ddd:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(ContactDto))]
        public async Task<IActionResult> GetByDdd(int ddd)
        {
            var contact = await _contactsService.GetContactsByDDDAsync(ddd);

            if (contact.Data.Count != 0)
                return Ok(contact.Data);

            return NotFound();
        }

        /// <summary>
        /// Insere um novo contato.
        /// </summary>
        /// <returns>Status 201 Created, ou 400 BadRequest.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert(CreateOrEditContactInputModel contact)
        {
            var result = await _contactsService.CreateContactAsync(contact);
            
            if (result.IsSuccess)
                return Created();

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Atualiza um contato existente.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>Status 204 No Content, ou 404 Not Found.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(CreateOrEditContactInputModel contact)
        {
            var result = await _contactsService.UpdateContactAsync(contact);

            if(result.IsSuccess)
                return NoContent();

            return BadRequest(result.Message);
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
            var result = await _contactsService.DeleteContactAsync(id);
            
            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result.Message);
        }
    }

}
