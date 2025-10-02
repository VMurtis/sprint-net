using Challenge.Domain.Models;
using Challenge.Infrastructure.Data.Interfaces;


namespace Challenge.Infrastructure.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Task<UsuarioEntity?> AdicionarAsync(UsuarioEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntity?> DeletarAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntity?> EditarAsync(int Id, UsuarioEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioEntity>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntity?> ObterUmAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
