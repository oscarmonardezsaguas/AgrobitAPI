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
    public class ProductoController : ControllerBase
    {
        [HttpGet("getproductos/{db}")]
        public IActionResult GetProductos(string db)
        {
            Consultas_Producto con = new Consultas_Producto(db);
            var res = con.getProductos();

            return Ok(res);
        }
    }
}