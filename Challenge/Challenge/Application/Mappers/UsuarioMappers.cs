using Challenge.Application.Dtos;
using Challenge.Domain.Models;

namespace Challenge.Application.Mappers
{
    public static class UsuarioMappers
    {
        public static UsuarioEntity ToUsuarioEntity(this UsuarioDto obj)
        {
            return new UsuarioEntity
            {
                Nome = obj.Nome,
                Email = obj.Email,
                Cpf = obj.Cpf,
                Telefone = obj.Telefone
                
            };
        }
    }
}
