using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        /// <summary>
        /// Retorna todos os contatos.
        /// </summary>
        /// <returns>Status 200 OK se encontrado, ou 404 Not Found.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Produces()]
        public async Task<IActionResult> GetAll()
        {
            await Task.CompletedTask;
            return Ok(); 
        }

        /// <summary>
        /// Retorna um contato específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do contato.</param>
        /// <returns>Status 200 OK se encontrado, ou 404 Not Found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Produces()]
        public async Task<IActionResult> GetById(int id)
        {
            await Task.CompletedTask;
            return Ok(); 
        }

        /// <summary>
        /// Insere um novo contato.
        /// </summary>
        /// <returns>Status 201 Created, ou 400 BadRequest.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Produces()]
        public async Task<IActionResult> Insert()
        {
            await Task.CompletedTask;
            return StatusCode(201); 
        }

        /// <summary>
        /// Atualiza um contato existente.
        /// </summary>
        /// <param name="id">O ID do contato.</param>
        /// <returns>Status 204 No Content, ou 404 Not Found.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id)
        {
            await Task.CompletedTask;
            return NoContent(); 
        }

        /// <summary>
        /// Deleta um contato pelo ID.
        /// </summary>
        /// <param name="id">O ID do contato.</param>
        /// <returns>Status 204 No Content, ou 404 Not Found.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Produces()]
        public async Task<IActionResult> Delete(int id)
        {
            await Task.CompletedTask;
            return NoContent(); 
        }
    }

}
