using Challenge.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Challenge.Doc.Samples
{
    public class UsuarioResponseSample : IExamplesProvider<UsuarioEntity>
    {
        public  UsuarioEntity GetExamples()
        {
            return new UsuarioEntity
            {
                Id = 2,
                Nome = "Marcos Oliveira",
                Email = "marcos.oliveira@outlook.com",
                Cpf = "99999999900",
                Telefone = "(11) 91313-0202",

            };
        }
    }
}
