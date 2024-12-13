namespace TwoOne.Domain.Entities.ValueObjects;

public class Name : IEquatable<Name>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string MiddleName { get; }

    public Name(string firstName, string lastName, string middleName = "")
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }
    
    public override string ToString() => $"{FirstName} {LastName}";

    public bool Equals(Name? other)
    {
        if (other == null)
            return false;

        return FirstName == other.FirstName &&
               LastName == other.LastName &&
               MiddleName == other.MiddleName;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Name otherName)
        {
            return Equals(otherName);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, MiddleName);
    }
}
