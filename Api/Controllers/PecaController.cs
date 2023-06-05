using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class PecaController : BaseApiController
    {
        private readonly UnitOfWork _unitOfWork;
        public PecaController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("AddPeca")]
        public async Task<ActionResult> AddPeca(Peca peca)
        {
            _unitOfWork.pecaRepository.AddPeca(peca);
            if(await _unitOfWork.Complete()) return Ok();

            return BadRequest("Não foi possivel adicionar a peça");
        }

        [HttpGet("GetPeca/{namePeca}")]
        public Peca GetPeca(string namePeca)
        {
            return _unitOfWork.pecaRepository.GetPeca(namePeca);
        }

        [HttpDelete("DeletePeca/{id}")]
        public async Task<ActionResult> DeletePeca(int id)
        {
            _unitOfWork.pecaRepository.DeletePeca(id);

            if(await _unitOfWork.Complete()) return Ok();

            return BadRequest("Peça não encontrada");
        }

        }
}