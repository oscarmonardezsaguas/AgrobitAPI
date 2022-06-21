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
    public class FertilizaController : ControllerBase
    {
        [HttpPost("crear/{db}")]
        public IActionResult Crear([FromBody] Fertiliza[] fertiliza, string db)
        {
            if (ModelState.IsValid)
            {
                foreach(Fertiliza x in fertiliza)
                {
                    Consultas_Temporada cont = new Consultas_Temporada(db);
                    x.temporada = Int32.Parse(cont.GetTemporada());

                    Consultas_Fertiliza conf = new Consultas_Fertiliza(db);
                    var res = conf.CrearFertiliza(x);
                }

                return Ok(fertiliza);
            } else
            {
                return BadRequest();
            }
        }
    }
}