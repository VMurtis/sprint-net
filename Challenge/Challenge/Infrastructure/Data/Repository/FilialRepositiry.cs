using Challenge.Domain.Models;
using Challenge.Infrastructure.Data.Interfaces;

namespace Challenge.Infrastructure.Data.Repository
{
    public class FilialRepository : IFialialRepository
    {
        private readonly ApplicationContext _context;

        public FilialRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Task<FilialEntity?> AdicionarAsync(FilialEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<FilialEntity?> DeletarAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<FilialEntity?> EditarAsync(int Id, FilialEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FilialEntity>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FilialEntity?> ObterUmAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
