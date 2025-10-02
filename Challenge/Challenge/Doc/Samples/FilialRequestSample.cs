using Challenge.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Challenge.Doc.Samples
{
    public class FilialRequestSample : IExamplesProvider<FilialEntity>
    {
        public FilialEntity GetExamples()
        {
            return new FilialEntity
            {
                Id = 1,
                FilialNome = "Filial Centro",
                Endereco = "Av. Paulista, 1000 - São Paulo/SP",
                Contato = "(11) 4002-8922",
                HorarioFuncionamento = "Seg a Sex - 08:00 às 18:00"
            };
        }
    }
}
