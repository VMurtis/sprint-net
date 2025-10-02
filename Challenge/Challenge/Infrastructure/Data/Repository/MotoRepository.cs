using Challenge.Domain.Models;
using Challenge.Infrastructure.Data.Interfaces;

namespace Challenge.Infrastructure.Data.Repository
{
    public class MotoRepository : IMotoRepository
    {
        private readonly ApplicationContext _context;

        public MotoRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Task<MotoEntity?> AdicionarAsync(MotoEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<MotoEntity?> DeletarAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<MotoEntity?> EditarAsync(int Id, MotoEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MotoEntity>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MotoEntity?> ObterUmAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
