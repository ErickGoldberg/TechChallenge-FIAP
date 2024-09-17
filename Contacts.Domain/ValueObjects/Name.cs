using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain.ValueObjects;
public class Name
{
    public Name()
    {
    }

    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    [Required]
    public string FirstName { get; private set; }
    [Required]
    public string LastName { get; private set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType()) return false;

        Name otherName = (Name)obj;
        return FirstName == otherName.FirstName && LastName == otherName.LastName;
    }

    public override int GetHashCode() =>
        (FirstName, LastName).GetHashCode();

    public override string ToString() =>
        $"{FirstName} {LastName}";
}
