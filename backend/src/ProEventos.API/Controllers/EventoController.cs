using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Evento>>> Get(
            [FromServices]DataContext context
        )
        {
            var eventos = await context.Eventos.AsNoTracking().ToListAsync();

            return Ok(eventos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Evento>> GetById(
            int id, 
            [FromServices]DataContext context
        )
        {
            var evento = await context.Eventos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if(evento == null)
                return NotFound(new { message = "Categoria não encontrada!"});

            return Ok(evento);
        }

        [HttpPost]
        [Route("")]
        public string Post()
        {
            return "Método POST";
        }



    }
}