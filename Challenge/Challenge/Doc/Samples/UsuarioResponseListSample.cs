using Challenge.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Challenge.Doc.Samples
{
    public class UsuarioResponseListSample : IExamplesProvider<IEnumerable<UsuarioEntity>>
    {
        public IEnumerable<UsuarioEntity> GetExamples()
        {
            return new List<UsuarioEntity> 
            {
                new UsuarioEntity
                {
                    Id = 1,
                    Nome = "Marcos Oliveira",
                    Email = "marcos.oliveira@outlook.com",
                    
                },
                 new UsuarioEntity
                 {
                     Id = 2,
                     Nome = "Alex Ferreira",
                     Email = "alex.ferreira@outlook.com",
                    
                 }

            }
            ;
        }

    }
}
