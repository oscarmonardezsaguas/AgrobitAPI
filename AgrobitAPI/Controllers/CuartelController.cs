using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgrobitAPI.Models;
using AgrobitAPI.Persistencia;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgrobitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CuartelController : ControllerBase
    {
        [Route("obtener")]
        [HttpPost]
        public IActionResult ObtenerCuarteles([FromBody] Cuartel cuartel)
        {
            Consultas_Cuartel con = new Consultas_Cuartel(cuartel.db);
            var resultado = con.GetCuartels();

            return Ok(new
            {
                data = resultado,
                prueba = cuartel.EspecieNombre
            });
        }
    }
}