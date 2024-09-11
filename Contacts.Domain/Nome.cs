using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain
public class Nome(string PrimeiroNome, string sobrenome)
{
    [Required]
    public string PrimeiroNome { get; private set; } = PrimeiroNome;
    [Required]
    public string Sobrenome { get; private set; } = sobrenome;

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType()) return false;

        Nome outroNome = (Nome)obj;
        return PrimeiroNome == outroNome.PrimeiroNome && Sobrenome == outroNome.Sobrenome;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PrimeiroNome, Sobrenome);
    }

    public override string ToString()
    {
        return $"{PrimeiroNome} {Sobrenome}";
    }
}
