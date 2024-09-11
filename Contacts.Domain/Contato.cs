namespace test_pass;
public class Contato(Nome nome, Telefone telefone, Email email)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Nome Nome { get; set; } = nome;
    public Email Email { get; set; } = email;
    public Telefone Telefone { get; set; } = telefone;


    public void AlterarNome(Nome NovoNome)
    {
        if (NovoNome is null) throw new ArgumentException("O nome não pode ser vazio.");
        Nome = NovoNome;
    }

    public void AlterarEmail(Email NovoEmail)
    {
        if (NovoEmail is null) throw new ArgumentException("O email não pode ser vazio.");
        Email = NovoEmail;
    }

    public void AlterarTelefone(Telefone NovoTelefone)
    {
        if (NovoTelefone is null) throw new ArgumentException("O telefone não pode ser vazio.");
        Telefone = NovoTelefone;
    }
}

