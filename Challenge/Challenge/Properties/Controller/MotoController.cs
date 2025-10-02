using Challenge.Application.Dtos;
using Challenge.Doc.Samples;
using Challenge.Domain.Models;
using Challenge.Infrastructure.Data.Interfaces;
using Challenge.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Challenge.Properties.Controller
{
    [Table("tb_moto")]
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {
        private readonly IMotoRepository _motoRepository;
        private readonly ApplicationContext _context;

        public MotoController(IMotoRepository motoRepository, ApplicationContext context)
        {
            _motoRepository = motoRepository;
            _context = context;
        }

        // ====================== GET ALL ======================
        [HttpGet]
        [EnableRateLimiting("rateLimitePolicy")]
        [SwaggerOperation(
            Summary = "Lista motos",
            Description = "Retorna a lista completa de motos cadastrados."
        )]
        [SwaggerResponse(statusCode: 200, description: "Lista retornada com sucesso", type: typeof(IEnumerable<MotoEntity>))]
        [SwaggerResponse(statusCode: 204, description: "Não possui dados para moto")]
        [SwaggerResponseExample(statusCode: 200, typeof(MotoResponseListSample))]
        public async Task<IActionResult> Get()
        {
            
            var motos = await _context.Moto.ToListAsync();
            if (!motos.Any())
                return NoContent();



            var hateoas = new
            {
                data = motos.Select(m => new
                {
                    m.Modelo,
                    m.Placa,
                    m.Chassi,
                    m.UsuarioId,
                    m.IotInfo,
                    m.RfidTag,
                    m.Localizacao,
                    m.StatusAtual,
                    m.IdFilial,
                    m.FilialId,
                    links = new
                    {
                        self = Url.Action(nameof(Get), "Moto",
                            new { id = m.IdMoto }, Request.Scheme),
                        update = Url.Action(nameof(Put), "Moto",
                            new { id = m.IdMoto }, Request.Scheme),
                        delete = Url.Action(nameof(Delete), "Moto",
                            new { id = m.IdMoto }, Request.Scheme)
                    }
                }),
                links = new
                {
                    self = Url.Action(nameof(Get), "Moto", null, Request.Scheme),
                    create = Url.Action(nameof(Post), "Moto", null, Request.Scheme)
                }
            };

            return Ok(hateoas);
        }

        
        [SwaggerOperation(
            Summary = "Busca um Moto pelo ID",
            Description = "Retorna um Moto específico a partir do seu ID.")]
        [SwaggerResponse(200, "Moto encontrado com sucesso", typeof(MotoEntity))]
        [SwaggerResponse(404, "Moto não encontrado")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _context.Moto.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        
        [HttpPost]
        [SwaggerRequestExample(typeof(MotoDto), typeof(MotoRequestSample))]
        [SwaggerResponse(statusCode: 201, description: "Moto salvo com sucesso", type: typeof(MotoEntity))]
        [SwaggerResponse(statusCode: 400, description: "Requisição inválida")]
        [SwaggerResponseExample(statusCode: 201, typeof(MotoResponseSample))]
        public async Task<IActionResult> Post(int id, MotoDto entity)
        {

            try
            {
                var result
               = await _motoRepository.AdicionarAsync(entity.ToMotoEntity());
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        [SwaggerOperation(
            Summary = "Atualiza um moto existente",
            Description = "Atualiza os dados de um moto já cadastrado.")]
        [SwaggerResponse(200, "Moto atualizado com sucesso", typeof(MotoEntity))]
        [SwaggerResponse(404, "Moto não encontrado")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MotoDto entity)
        {


            var result = await _motoRepository.EditarAsync(id, entity.ToMotoEntity());

            if (result is null)
                return NotFound();
            return Ok(entity);
        }

        
        [SwaggerOperation(
            Summary = "Exclui um moto",
            Description = "Remove um moto específico do banco de dados.")]
        [SwaggerResponse(200, "Moto excluído com sucesso", typeof(MotoEntity))]
        [SwaggerResponse(404, "Moto não encontrado")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Moto.FindAsync(id);
            if (entity is null)
            {
                return NotFound();
            }
            _context.Moto.Remove(entity);       
            await _context.SaveChangesAsync();
            return Ok(entity);
        }
    }
}
