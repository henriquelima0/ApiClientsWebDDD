using ApiClientsDDD.Domain.Models.Enums;
using ApiClientsDDD.Domain.Models;

namespace ApiClientsDDD.Domain.ValueObjects;

public class Address : Base
{
    public string Street { get; set; }
    public string? City { get; set; }
    public string Number { get; set; }
    public AddressType AddressType { get; set; }
    public Guid ClientId { get; set; } 
    public Client Client { get; init; }

    public Address()
    {
        
    }
    public Address(AddressType addressType, string street, string number, string city, Guid clientId)
    {
        Street = street;
        Number = number;
        AddressType = addressType;
        City = city;
        ClientId = clientId;
    }
}
