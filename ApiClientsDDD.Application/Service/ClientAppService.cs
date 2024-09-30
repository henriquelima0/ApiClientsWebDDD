using ApiClientsDDD.Application.DTOs;
using ApiClientsDDD.Application.Interfaces;
using ApiClientsDDD.Domain.Interfaces;
using ApiClientsDDD.Domain.Models;
using AutoMapper;

namespace ApiClientsDDD.Application.Service;

public class ClientAppService : IClientAppService
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public ClientAppService(IClientRepository clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientDTO>> GetAllAsync()
    {
        var clients = await _clientRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ClientDTO>>(clients);
    }

    public async Task<ClientDTO> GetByIdAsync(Guid id)
    {
        var client = await _clientRepository.GetByIdAsync(id);
        return _mapper.Map<ClientDTO>(client);
    }

    public async Task AddAsync(ClientDTO clientDto)
    {
        var client = _mapper.Map<Client>(clientDto);

        foreach (var address in client.Addresses)
        {
            address.ClientId = client.Id;  
        }
        await _clientRepository.AddAsync(client);
        await _clientRepository.SaveChangesAsync();
    }



    public async Task UpdateAsync(ClientDTO clientDto)
    {
        var client = _mapper.Map<Client>(clientDto);
        await _clientRepository.UpdateAsync(client);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _clientRepository.DeleteAsync(id);
    }
}