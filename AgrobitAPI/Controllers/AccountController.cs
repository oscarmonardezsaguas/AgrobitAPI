using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using AgrobitAPI.Models;
using agrobit.Models;

namespace AgrobitAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext context;

        public AccountController(IConfiguration configuration, ApplicationDbContext context)
        {
            this._configuration = configuration;
            this.context = context;
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Usuario userInfo)
        {
            if (ModelState.IsValid)
            {
                string clave = Funciones.Encrypt(userInfo.Clave);
                var result = context.Usuario
                    .FirstOrDefault(x => x.Email == userInfo.Email && x.Clave == clave);

                if(result != null)
                {
                    return BuildToken(result);
                } else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
            } else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("searchrut")]
        public IActionResult SearchRut([FromBody] string rut)
        {
            var result = context.Usuario_Rut.FirstOrDefault(x => x.Rut == rut);

            if (result != null)
            {
                return Ok(result);
            } else
            {
                return BadRequest();
            }
        }

        private IActionResult BuildToken(Usuario userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
               
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Llave_Super_Secreta"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(3);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration,
                data = userInfo
            });

        }
    }
}