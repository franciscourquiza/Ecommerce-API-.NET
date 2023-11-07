using AutoMapper;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;
using e_commerce_API.Data.Enum;
using e_commerce_API.Models;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_API.Services.Implementations
{
    public class ClientService : IClientService
    {
        private EcommerceContext _context;
        private readonly IMapper _mapper;
        public ClientService(EcommerceContext context ,IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Client> GetClients() 
        {
            return  _context.Clients.ToList();
        }

        public void AddClient(ClientDto newClient)
        {
            Client? userEntity = _mapper.Map<Client>(newClient);
            if (userEntity == null)
            {
                throw new ArgumentNullException(nameof(userEntity));
            }
            _context.Add(userEntity);
        }

        public void EditClient(EditClientDto client, string emailClient) 
        {
            Client clientToEdit = _context.Clients.SingleOrDefault(u => u.Email == emailClient);
            Client clientEdited = _mapper.Map(client, clientToEdit);

            _context.Clients.Update(clientEdited);
        } 
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); 
        }
    }
}
