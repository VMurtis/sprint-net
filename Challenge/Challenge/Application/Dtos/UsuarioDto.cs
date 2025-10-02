using Challenge.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Application.Dtos
{
    public record UsuarioDto(string Nome, string Email, string Cpf, string Telefone)
    {
        public UsuarioEntity ToUsuarioEntity()
        {
            return new UsuarioEntity
            {
                Nome = Nome,
                Email = Email,
                Cpf = Cpf,
                Telefone = Telefone
            };
        }
    }
}
