using api.Dtos;
using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class VendaPecasController : BaseApiController
    {
        private readonly UnitOfWork _unitOfWork;
        public VendaPecasController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("AddVendaPeca")]
        public async Task<ActionResult> AddVendaPeca(VendaPeca vendaPeca)
        {
            
            foreach (var item in vendaPeca.ItemPeca)
            {
                if(item.Peca == null)
                {
                  item.Peca = await _unitOfWork.pecaRepository.GetPecaId(item.IdPeca);
                }
                
            }

            
            
            _unitOfWork.vendaPecaRepository.AddVendaPeca(vendaPeca);

            if(await _unitOfWork.Complete()) return Ok();

            return BadRequest();
        }
        

        [HttpGet("GetCPecaVenda/{nameClient}")]
        public IEnumerable<VendaPecaDto> GetCVendaPeca(string nameClient)
        {
            return _unitOfWork.vendaPecaRepository.GetCVendaPeca(nameClient);
        }

        [HttpGet("GetDPecaVenda/{date}")]
        public IEnumerable<VendaPecaDto> GetDVendaPeca(DateTime date)
        {
            return _unitOfWork.vendaPecaRepository.GetDVendaPeca(date);
        }
    }
}