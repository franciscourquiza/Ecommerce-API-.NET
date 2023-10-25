using AutoMapper;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;
using e_commerce_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_API.Services.Implementations
{
    public class ClientService : IClientService
    {
        private EcommerceContext _context;
        private readonly IMapper _mapper;
        public ClientService(EcommerceContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync() 
        {
            return await _context.Clients.ToListAsync();
        }
    }
}
