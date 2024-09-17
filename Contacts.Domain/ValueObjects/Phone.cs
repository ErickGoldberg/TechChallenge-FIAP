using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain.ValueObjects;
public class Phone
{
    public Phone()
    {
    }

    public Phone(int dDD, int number)
    {
        DDD = dDD;
        Number = number;
    }

    [Required]
    [Length(2, 2, ErrorMessage = "O tamanho do DDD deve ser de 2 digitos"), Range(11, 99, ErrorMessage = "DDD inválido - O DDD deve estar entre 11 ou 99")]
    public int DDD { get; private set; }
    [Required]
    [Length(8, 9, ErrorMessage = "O tamanho do telefone deve ser de 8 a 9 digitos")]
    public int Number { get; private set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType()) return false;

        var otherPhone = (Phone)obj;
        return DDD == otherPhone.DDD && Number == otherPhone.Number;
    }

    public override int GetHashCode() =>
        (DDD, Number).GetHashCode();

    public override string ToString() =>
        $"({DDD}) {Number}";
}
