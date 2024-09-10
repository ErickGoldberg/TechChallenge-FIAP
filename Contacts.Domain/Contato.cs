namespace Contacts.Domain
{
    public class Contato(string nome, int ddd, string telefone, string email)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = nome;
        public string Email { get; set; } = email;
        public int DDD { get; set; } = ddd;
        public string Telefone { get; set; } = telefone;


        public void AlterarNome(string NovoNome)
        {
            if (NovoNome is null) throw new ArgumentException("O nome não pode ser vazio.");
            Nome = NovoNome;
        }

        public void AlterarEmail(string NovoEmail)
        {
            if (NovoEmail is null) throw new ArgumentException("O email não pode ser vazio.");
            Email = NovoEmail;
        }

        public void AlterarTelefone(string NovoTelefone)
        {
            if (NovoTelefone is null) throw new ArgumentException("O telefone não pode ser vazio.");
            Email = NovoTelefone;
        }
    }
}