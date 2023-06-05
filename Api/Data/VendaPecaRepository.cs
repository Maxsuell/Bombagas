using api.Dtos;
using Api.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Api.Data
{
    public class VendaPecaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public VendaPecaRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddVendaPeca(VendaPeca vendaPeca)
        {
            _context.vendaPecas.Add(vendaPeca);
        }

        public  IEnumerable<VendaPecaDto> GetCVendaPeca(string nameClient)
        {
            return _context.vendaPecas.ProjectTo<VendaPecaDto>(_mapper.ConfigurationProvider).Where(vp => vp.NameClient == nameClient);
        }

        public  IEnumerable<VendaPecaDto> GetDVendaPeca(DateTime date)
        {
            return _context.vendaPecas.ProjectTo<VendaPecaDto>(_mapper.ConfigurationProvider).Where(vp => vp.Data == date);
        }
    }
}