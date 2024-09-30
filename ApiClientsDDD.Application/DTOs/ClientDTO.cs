using ApiClientsDDD.Application.DTOs;

public class ClientDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }  
    public List<AddressDTO> Addresses { get; set; } = new List<AddressDTO>();
}
