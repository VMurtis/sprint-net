using Challenge.Application.Dtos;
using Challenge.Doc.Samples;
using Challenge.Domain.Models;
using Challenge.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Challenge.Properties.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilialController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public FilialController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/filial
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FilialEntity>>> GetAll()
        {
            var filiais = await _context.Filial.ToListAsync();
            return Ok(filiais);
        }

        // GET: api/filial/{id}
        [HttpGet]
        [EnableRateLimiting("rateLimitePolicy")]
        [SwaggerOperation(
            Summary = "Lista Filiais",
            Description = "Retorna a lista completa de filiais cadastrados."
        )]
        [SwaggerResponse(statusCode: 200, description: "Lista retornada com sucesso", type: typeof(IEnumerable<FilialEntity>))]
        [SwaggerResponse(statusCode: 204, description: "Não possui dados para filial")]
        [SwaggerResponseExample(statusCode: 200, typeof(FilialResponseListSample))]
        public async Task<ActionResult<FilialEntity>> GetById(long id)
        {
            var filial = await _context.Filial.FindAsync(id);

            if (filial == null)
                return NotFound(new { message = "Filial não encontrada." });

            return Ok(filial);
        }

        // POST: api/filial
        [HttpPost]
        [SwaggerRequestExample(typeof(FilialDto), typeof(FilialRequestSample))]
        [SwaggerResponse(statusCode: 201, description: "Filial salvo com sucesso", type: typeof(FilialEntity))]
        [SwaggerResponse(statusCode: 400, description: "Requisição inválida")]
        [SwaggerResponseExample(statusCode: 201, typeof(FilialResponseSample))]
        public async Task<ActionResult<FilialEntity>> Create([FromBody] FilialDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var filial = dto.ToFilialEntity();

            _context.Filial.Add(filial);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = filial.Id }, filial);
        }

        // PUT: api/filial/{id}
        [SwaggerOperation(
            Summary = "Atualiza um filial existente",
            Description = "Atualiza os dados de um filial já cadastrado.")]
        [SwaggerResponse(200, "Filial atualizado com sucesso", typeof(FilialEntity))]
        [SwaggerResponse(404, "Filial não encontrado")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] FilialDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var filial = await _context.Filial.FindAsync(id);
            if (filial == null)
                return NotFound(new { message = "Filial não encontrada." });

            filial.FilialNome = dto.FilialNome;
            filial.Endereco = dto.Endereco;
            filial.Contato = dto.Contato;
            filial.HorarioFuncionamento = dto.HorarioFuncionamento;

            _context.Filial.Update(filial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [SwaggerOperation(
            Summary = "Exclui um filial",
            Description = "Remove um filial específico do banco de dados.")]
        [SwaggerResponse(200, "Filial excluído com sucesso", typeof(FilialEntity))]
        [SwaggerResponse(404, "Filial não encontrado")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var filial = await _context.Filial.FindAsync(id);
            if (filial == null)
                return NotFound(new { message = "Filial não encontrada." });

            _context.Filial.Remove(filial);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
