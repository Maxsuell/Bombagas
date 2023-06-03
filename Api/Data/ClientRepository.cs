using api.Dtos;
using Api.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ClientRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ClientRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public void AddClient(ClientApp clientApp)
        {
            _context.clientApps.Add(clientApp);
        }

        public async Task<IEnumerable<ClientDto>> GetClients()
        {
            return await _context.clientApps.ProjectTo<ClientDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<ClientApp> GetClient(string nameClient)
        {
            return await _context.clientApps.SingleOrDefaultAsync(c => c.NameClient == nameClient);
        }

        public async Task<ClientDto> GetClientIdDto(int id)
        {
            var client = await _context.clientApps
                .Include(c => c.Contatos)
                .FirstOrDefaultAsync(cl => cl.Id == id);

            var clientMap = _mapper.Map<ClientDto>(client);

            return clientMap;
            
        }

        public async Task<ClientApp> GetClientId(int id)
        {
            return await _context.clientApps
                .Include(c => c.Contatos)
                .FirstOrDefaultAsync(cl => cl.Id == id);  
        }
        
    }
}