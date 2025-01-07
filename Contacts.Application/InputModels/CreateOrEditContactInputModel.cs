using System.ComponentModel.DataAnnotations;

namespace Contacts.Application.InputModels
{
    public class CreateOrEditContactInputModel
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "O endereço de email não é valido")]
        public string Email { get; set; }

        [Required]
        [Range(11, 99, ErrorMessage = "DDD inválido - O DDD deve estar entre 11 ou 99")]
        public int DDD { get; set; }

        [Required]
        [Range(10000000, 999999999, ErrorMessage = "O tamanho do telefone deve ser de 8 a 9 dígitos")]
        public int Number { get; set; }

    }
}
