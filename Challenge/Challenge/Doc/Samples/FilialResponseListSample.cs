using Challenge.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Challenge.Doc.Samples
{
    public class FilialResponseListSample : IExamplesProvider<IEnumerable<FilialEntity>>
    {
        public IEnumerable<FilialEntity> GetExamples()
        {
            return new List<FilialEntity>
            {
                new FilialEntity
                {
                    Id = 1,
                    FilialNome = "Filial Centro",
                    Endereco = "Av. Paulista, 1000 - São Paulo/SP",
                    Contato = "(11) 4002-8922",
                    HorarioFuncionamento = "Seg a Sex - 08:00 às 18:00"
                },
                new FilialEntity
                {
                    Id = 2,
                    FilialNome = "Filial Zona Sul",
                    Endereco = "Rua das Flores, 250 - São Paulo/SP",
                    Contato = "(11) 3555-7890",
                    HorarioFuncionamento = "Seg a Sáb - 09:00 às 19:00"
                }
            };
        }
    }
}
