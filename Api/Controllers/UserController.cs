using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UserController : BaseApiController
    {

        private readonly UnitOfWork _unitOfWork;

        public UserController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetUser()
        {
            return await _unitOfWork.userRepository.GetUser();
        }

        [HttpPost("Add")]
        public async Task<ActionResult<bool>> AddUser(UserApp userApp)
        {
            _unitOfWork.userRepository.AddUser(userApp);
            return await _unitOfWork.Complete();
        }
    }
}