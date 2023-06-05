using Api.Entities;

namespace Api.Data
{
    public class PecaRepository
    {
        private readonly DataContext _context;
        public PecaRepository(DataContext context)
        {
            _context = context;
        }

        public void AddPeca(Peca peca)
        {
            _context.peca.Add(peca);
        }

        public Peca GetPeca(string namePeca)
        {
            return _context.peca.SingleOrDefault(p => p.NamePeca == namePeca);
        }

        public async Task<Peca> GetPecaId(int id)
        {
            return await _context.peca.FindAsync(id);
        }

        public void DeletePeca(int id)
        {
            var obj = _context.peca.Find(id);
            _context.Remove(obj);

        }

        
    }
}