using ApiClientsDDD.Domain.Models;
using ApiClientsDDD.Domain.Models.Enums;

namespace ApiClientsDDD.Application.DTOs;

public class AddressDTO
{
    public Guid Id { get; set; }
    public AddressType Type { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
}
