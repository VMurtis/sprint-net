using Challenge.Application.Dtos;
using Challenge.Doc.Samples;
using Challenge.Domain.Models;
using Challenge.Infrastructure.Data;
using Challenge.Infrastructure.Data.Interfaces;
//using Challenge.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Properties.Controller
{
    [Table("tb_usuario")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioControllerer : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ApplicationContext _context;

        public UsuarioControllerer(
            IUsuarioRepository usuarioRepository,
            ApplicationContext context)
        {
            _usuarioRepository = usuarioRepository;
            _context = context;
        }

        // ====================== GET ALL ======================
        [HttpGet]
        [EnableRateLimiting("rateLimitePolicy")]
        [SwaggerOperation(
            Summary = "Lista usuários",
            Description = "Retorna a lista completa de usuários cadastrados."
        )]
        [SwaggerResponse(statusCode: 200, description: "Lista retornada com sucesso", type: typeof(IEnumerable<UsuarioEntity>))]
        [SwaggerResponse(statusCode: 204, description: "Não possui dados para usuários")]
        [SwaggerResponseExample(statusCode: 200, typeof(UsuarioResponseListSample))]
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
            var usuarios = await _context.Usuario.ToListAsync();
            if (!usuarios.Any())
                return NoContent();

            var hateoas = new
            {
                data = usuarios.Select(u => new
                {
                    u.Id,
                    u.Nome,
                    u.Email,
                    u.Cpf,
                    u.Telefone,
                    links = new
                    {
                        self = Url.Action(nameof(Get), "Usuario",
                            new { id = u.Id }, Request.Scheme),
                        update = Url.Action(nameof(Put), "Usuario",
                            new { id = u.Id }, Request.Scheme),
                        delete = Url.Action(nameof(Delete), "Usuario",
                            new { id = u.Id }, Request.Scheme)
                    }
                }),
                links = new
                {
                    self = Url.Action(nameof(Get), "Usuario", null, Request.Scheme),
                    create = Url.Action(nameof(Post), "Usuario", null, Request.Scheme)
                }
            };

            return Ok(hateoas);
        }

        // ====================== GET BY ID ======================
        [SwaggerOperation(
            Summary = "Busca um usuário pelo ID",
            Description = "Retorna um usuário específico a partir do seu ID.")]
        [SwaggerResponse(200, "Usuário encontrado com sucesso", typeof(UsuarioEntity))]
        [SwaggerResponse(404, "Usuário não encontrado")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _context.Usuario.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // ====================== POST ======================
        [HttpPost]
        [SwaggerRequestExample(typeof(UsuarioDto), typeof(UsuarioRequestSample))]
        [SwaggerResponse(statusCode: 201, description: "Usuário salvo com sucesso", type: typeof(UsuarioEntity))]
        [SwaggerResponse(statusCode: 400, description: "Requisição inválida")]
        [SwaggerResponseExample(statusCode: 201, typeof(UsuarioResponseSample))]
        public async Task<IActionResult> Post(int id, UsuarioDto entity)
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
               = await _usuarioRepository.AdicionarAsync(entity.ToUsuarioEntity());
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // ====================== PUT ======================
        [SwaggerOperation(
            Summary = "Atualiza um usuário existente",
            Description = "Atualiza os dados de um usuário já cadastrado.")]
        [SwaggerResponse(200, "Usuário atualizado com sucesso", typeof(UsuarioEntity))]
        [SwaggerResponse(404, "Usuário não encontrado")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UsuarioDto entity)
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

            var result = await _usuarioRepository.EditarAsync(id, entity.ToUsuarioEntity());

            if (result is null)
                return NotFound();
            return Ok(entity);
        }

        // ====================== DELETE ======================
        [SwaggerOperation(
            Summary = "Exclui um usuário",
            Description = "Remove um usuário específico do banco de dados.")]
        [SwaggerResponse(200, "Usuário excluído com sucesso", typeof(UsuarioEntity))]
        [SwaggerResponse(404, "Usuário não encontrado")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Usuario.FindAsync(id);
            if (entity is null)
            {
                return NotFound();
            }
            _context.Usuario.Remove(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }
    }
}
