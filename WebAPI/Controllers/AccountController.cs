using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Interfaces;


namespace WebAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork uow;
        public AccountController(IUnitOfWork uow)
        {
            this.uow = uow;

        }

        // api/account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto loginReq)
        {
            var user = await uow.UserRepository.AuthenticateUser(loginReq.UserName, loginReq.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var loginRes = new LoginResponseDto();
            loginRes.UserName = user.Username;
            loginRes.Token = "Token to be generated";

            return Ok(loginRes);
        }
    }
}