using e_commerce_API.Data.Entities;

namespace e_commerce_API.Services.Interfaces
{
    public interface IClientService
    {
        List<Client> GetClients();
        void AddClient(Client clientForCreation);
        Task<bool> SaveChangesAsync();
    }
}
