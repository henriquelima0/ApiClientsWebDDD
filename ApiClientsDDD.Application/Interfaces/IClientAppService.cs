using ApiClientsDDD.Application.DTOs;

namespace ApiClientsDDD.Application.Interfaces;

public interface IClientAppService
{
    Task<IEnumerable<ClientDTO>> GetAllAsync();
    Task<ClientDTO> GetByIdAsync(Guid id);
    Task AddAsync(ClientDTO clientDto);
    Task UpdateAsync(ClientDTO clientDto);
    Task DeleteAsync(Guid id);
    
}
