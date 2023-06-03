using AutoMapper;

namespace Api.Data
{
    public class UnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public UserRepository userRepository => new UserRepository(_context);

        public ClientRepository clientRepository => new ClientRepository(_context, _mapper);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}