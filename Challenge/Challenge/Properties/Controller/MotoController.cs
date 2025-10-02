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
            /*var usuarios = await _context.Usuario.ToListAsync();
            if (!usuarios.Any())
                return NoContent();

            var Id = result.FirstOrDefault()?.Id ?? 0;

            var hateoas = new
            {
                data = result,
                links = new
                {
                    self = Url.Action(nameof(Get), "Usuario", null),
                    getById = Url.Action(nameof(Get), "Usuario", new { id = Id }),
                    put = Url.Action(nameof(Put), "Usuario", new { id = Id }),
                    delete = Url.Action(nameof(Delete), "Usuario", new { Id = Id }),
                }


            };*/
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
                    //m.MotoLogId,
                    m.UsuarioId2,
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

        // ====================== GET BY ID ======================
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

        // ====================== POST ======================
        [HttpPost]
        [SwaggerRequestExample(typeof(MotoDto), typeof(MotoRequestSample))]
        [SwaggerResponse(statusCode: 201, description: "Moto salvo com sucesso", type: typeof(MotoEntity))]
        [SwaggerResponse(statusCode: 400, description: "Requisição inválida")]
        [SwaggerResponseExample(statusCode: 201, typeof(MotoResponseSample))]
        public async Task<IActionResult> Post(int id, MotoDto entity)
        {
            /*if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Convertendo DTO para Entity
            var usuarioEntity = new UsuarioEntity
            {
                Nome = entity.Nome,
                Email = entity.Email,
                Cpf = entity.Cpf,
                Telefone = entity.Telefone
            };

            _context.Usuario.Add(usuarioEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = usuarioEntity.Id }, usuarioEntity);*/
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

        // ====================== PUT ======================
        [SwaggerOperation(
            Summary = "Atualiza um moto existente",
            Description = "Atualiza os dados de um moto já cadastrado.")]
        [SwaggerResponse(200, "Moto atualizado com sucesso", typeof(MotoEntity))]
        [SwaggerResponse(404, "Moto não encontrado")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MotoDto entity)
        {
            /*var usuarioExists = await _context.Usuario.FindAsync(id);
            if (usuarioExists is null)
                return NotFound();

            usuarioExists.Nome = usuarioEntity.Nome;
            usuarioExists.Email = usuarioEntity.Email;
            usuarioExists.Cpf = usuarioEntity.Cpf;
            usuarioExists.Telefone = usuarioEntity.Telefone;

            _context.Usuario.Update(usuarioExists);
            await _context.SaveChangesAsync();
            return Ok(usuarioExists);*/

            var result = await _motoRepository.EditarAsync(id, entity.ToMotoEntity());

            if (result is null)
                return NotFound();
            return Ok(entity);
        }

        // ====================== DELETE ======================
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
