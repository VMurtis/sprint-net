using Challenge.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Challenge.Doc.Samples
{
    public class UsuarioRequestSample : IExamplesProvider<UsuarioEntity>
    {
        public UsuarioEntity GetExamples()
        {
            return new UsuarioEntity
            {
                Id = 1,
                Nome = "Ana Silva",
                Email = "ana.silva@outlook.com",
                Cpf = "12345678901",
                Telefone = "(11) 98765-4321"
            };
        }
    }
}
