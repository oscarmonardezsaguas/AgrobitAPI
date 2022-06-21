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
    public class RiegoController : ControllerBase
    {
        [HttpGet("getproductores/{db}")]
        public IActionResult GetProductores(string db)
        {
            Consultas_Riego con = new Consultas_Riego(db);
            var res = con.getProductores();

            return Ok(res);
        }

        [HttpGet("getparcelas/{db}")]
        public IActionResult GetParcelas(string db, int productorId)
        {
            Consultas_Riego con = new Consultas_Riego(db);
            var res = con.getParcelas();

            return Ok(res);
        }

        [HttpGet("getespecies/{db}")]
        public IActionResult GetEspecies(string db, int productorId, int parcelaId)
        {
            Consultas_Riego con = new Consultas_Riego(db);
            var res = con.getEspecies();

            return Ok(res);
        }

        [HttpGet("getcuarteles/{db}")]
        public IActionResult GetCuarteles(string db)
        {
            Consultas_Riego con = new Consultas_Riego(db);
            var res = con.GetCuartels();

            return Ok(res);
        }

        [HttpPost("crear/{db}")]
        public IActionResult CrearRiego([FromBody]Riego[] riego, string db)
        {

            if (ModelState.IsValid)
            {
                foreach(Riego x in riego)
                {

                    Consultas_Temporada cont = new Consultas_Temporada(db);
                    x.Temporada = cont.GetTemporada();

                    Consultas_Riego conr = new Consultas_Riego(db);

                    var res = conr.CrearRiego(x);
                }
                return Ok(riego);
            } else
            {
                return BadRequest();
            }
        }
    }
}