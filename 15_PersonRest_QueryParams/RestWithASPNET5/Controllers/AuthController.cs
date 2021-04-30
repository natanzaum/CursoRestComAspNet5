using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET5.Business;
using RestWithASPNET5.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn([FromBody] UserVO user)
        {
            if(user == null)
            {
                return BadRequest("Requisição inválida!");
            }

            var token = _loginBusiness.ValidaCredenciais(user);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {
            if (tokenVo == null)
            {
                return BadRequest("Requisição inválida!");
            }

            var token = _loginBusiness.ValidaCredenciais(tokenVo);
            if (token == null)
            {
                return BadRequest("Requisição inválida!");
            }

            return Ok(token);
        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var userName = User.Identity.Name;

            var result = _loginBusiness.RevokeToken(userName);

            if (!result)
            {
                return BadRequest("Requisição inválida!");
            }

            return NoContent();
        }
    }
}
