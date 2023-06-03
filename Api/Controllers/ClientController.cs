using api.Dtos;
using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ClientController : BaseApiController
    {
        private readonly UnitOfWork _unitOfWork;
        public ClientController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Clients")]
        public async Task<IEnumerable<ClientDto>> GetClients()
        {
            return await _unitOfWork.clientRepository.GetClients();
        }

        [HttpGet("Client/{nome}")]
        public async Task<ClientApp> GetClient(string nome)
        {
            return await _unitOfWork.clientRepository.GetClient(nome);
        }

        [HttpGet("ClientId/{id}")]
        public async Task<ClientDto> GetClientId(int id)
        {
            return await _unitOfWork.clientRepository.GetClientIdDto(id);
        }

        [HttpPost("AddClient")]
        public async Task<bool> AddClient(ClientApp clientApp)
        {            
            _unitOfWork.clientRepository.AddClient(clientApp);
            return await _unitOfWork.Complete();
        }

        [HttpPost("AddContato")]
        public async Task<ActionResult> AddContato(Contatos contatos)
        {
            var client = await _unitOfWork.clientRepository.GetClientId(contatos.IdClient);
            
            if(client != null)
            {
                client.Contatos.Add(contatos);
                if(await _unitOfWork.Complete()) return Ok();
            }
            

            return BadRequest("Cliente não encontrado");
        }
    }
}