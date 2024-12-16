namespace TwoOne.Domain.Entities.ValueObjects;

public class Address : IEquatable<Address>
{
    public string Street { get; }
    public string City { get; }
    public string PostalCode { get; }
    public string Country { get; }

    public Address(string street, string city, string postalCode, string country)
    {
        Street = street;
        City = city;
        PostalCode = postalCode;
        Country = country;
    }

    public override string ToString() => $"{Street}, {City}, {PostalCode}, {Country}";

    public bool Equals(Address? other)
    {
        if (other == null)
            return false;

        return City == other.City &&
               PostalCode == other.PostalCode &&
               Country == other.Country;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Address otherAddress)
        {
            return Equals(otherAddress);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(City, PostalCode, Country);
    }
}
