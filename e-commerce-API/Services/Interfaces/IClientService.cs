using e_commerce_API.Data.Entities;
using e_commerce_API.Models;

namespace e_commerce_API.Services.Interfaces
{
    public interface IClientService
    {
        List<Client> GetClients();
        void AddClient(Client clientForCreation);
        void EditClient(EditClientDto clientEdited,string emailClient);
        Task<bool> SaveChangesAsync();

    }

}
