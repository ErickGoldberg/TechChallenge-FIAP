namespace Contacts.Domain
{
    public class Contato
    {
        public Contato() 
        {
        }
         
        public Contato(string nome, int ddd, string telefone, string email)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DDD = ddd;
            Telefone = telefone;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }  
        public string Email { get; set; }  
        public int DDD { get; set; }  
        public string Telefone { get; set; }  


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