using AutoMapper;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;
using e_commerce_API.Data.Enum;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_API.Services.Implementations
{
    public class ClientService : IClientService
    {
        private EcommerceContext _context;
        public ClientService(EcommerceContext context, IMapper mapper) 
        {
            _context = context;
        }
        public List<Client> GetClients() 
        {
            return  _context.Clients.ToList();
        }

        public void AddClient(Client newClient)
        {
            if (newClient == null)
            {
                throw new ArgumentNullException(nameof(newClient));
            }
            _context.Add(newClient);
        }
        public async Task<Client?> GetShoppingHistoryAsync(string userEmail, Order orderHistory)
        {
            return await _context.Clients
                .Where(h => h.Email == userEmail)
                .FirstOrDefaultAsync(h => h.Orders == orderHistory);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); //devuelve true si 1 o mas entidades fueron modificadas
        }
    }
}
