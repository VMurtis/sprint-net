using Challenge.Application.Dtos;
using Challenge.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Application.Mappers
{
    public static class FilialMappers
    {
        public static FilialEntity ToFilialEntity(this FilialDto obj)
        {
            return new FilialEntity
            {
                FilialNome = obj.FilialNome,
                Endereco = obj.Endereco,
                Contato = obj.Contato,
                HorarioFuncionamento = obj.HorarioFuncionamento

            };
        }
    }
}
