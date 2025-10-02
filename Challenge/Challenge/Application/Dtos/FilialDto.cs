using Challenge.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Application.Dtos
{
    public record FilialDto(string FilialNome, string Endereco, string Contato, string HorarioFuncionamento)
    {
        public FilialEntity ToFilialEntity()
        {
            return new FilialEntity
            {
                FilialNome = FilialNome,
                Endereco = Endereco,
                Contato = Contato,
                HorarioFuncionamento = HorarioFuncionamento
            };
        }
    }
}
