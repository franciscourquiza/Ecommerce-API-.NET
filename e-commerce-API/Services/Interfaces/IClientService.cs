using e_commerce_API.Data.Entities;

namespace e_commerce_API.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClientsAsync();
    }
}
