using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain
public class Telefone(string ddd, string numero)
{
    [Required]
    [Length(2, 2, ErrorMessage = "O tamanho do DDD deve ser de 2 digitos"), Range(11, 99, ErrorMessage = "DDD inválido - O DDD deve estar entre 11 ou 99")]
    public string DDD { get; private set; } = ddd;
    [Required]
    [Length(8, 9, ErrorMessage = "O tamanho do telefone deve ser de 8 a 9 digitos")]
    public string Numero { get; private set; } = numero;

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType()) return false;

        var outroTelefone = (Telefone)obj;
        return DDD == outroTelefone.DDD && Numero == outroTelefone.Numero;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(DDD.GetHashCode(), Numero.GetHashCode());
    }

    public override string ToString()
    {
        return $"({DDD}) {Numero}";
    }
}
