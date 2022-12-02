using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiLoteria.DTOs;
using WebApiLoteria.Entidades;
using Microsoft.EntityFrameworkCore;

namespace WebApiLoteria.Controllers
{
    [ApiController]
    [Route("premios")]

    public class PremioController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public PremioController(ApplicationDbContext context, IMapper mapper)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<GetPremioDTO>>> GetById(int id)
        {
            var premio = await dbContext.Premio.Where(premioDB => premioDB.rifaId == id).ToListAsync();
            if (premio == null)
            {
                return NotFound();
            }
            return mapper.Map<List<GetPremioDTO>>(premio);
        }

        [HttpPost("crearPremio")]
        public async Task<ActionResult> Post(int idRifa, PremioDTO premioDtO)
        {
            var rifaExiste = await dbContext.Rifas.AnyAsync(vetDB => vetDB.Id == idRifa);
            if (rifaExiste == false)
            {
                return NotFound();
            }

            var premio = mapper.Map<Premio>(premioDtO);
            premio.rifaId = idRifa;
            dbContext.Add(premio);
            await dbContext.SaveChangesAsync();

            var premioDTO = mapper.Map<GetPremioDTO>(premio);
            return Ok();
        }

        [HttpPut("{id:int} editarPremio")]
        public async Task<ActionResult> Put(int idRifa, int id, PremioDTO CrearPremioDTO)
        {
            var rifaExiste = await dbContext.Rifas.AnyAsync(vetDB => vetDB.Id == idRifa);
            if (rifaExiste == false)
            {
                return NotFound();
            }

            var premioExiste = await dbContext.Premio.AnyAsync(premioDB => premioDB.Id == id);

            if (premioExiste == false)
            {
                return NotFound();
            }

            var premio = mapper.Map<Premio>(CrearPremioDTO);
            premio.Id = id;
            premio.rifaId = idRifa;
            dbContext.Update(premio);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int} eliminarPremio")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await dbContext.Premio.AnyAsync(x => x.Id == id);
            if (existe == false)
            {
                return NotFound("No se encontró el premio");
            }
            dbContext.Remove(new Premio()
            {
                Id = id,
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
