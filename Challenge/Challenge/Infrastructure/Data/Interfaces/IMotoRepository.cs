using Challenge.Domain.Models;

namespace Challenge.Infrastructure.Data.Interfaces
{
    public interface IMotoRepository
    {
        Task<IEnumerable<MotoEntity>> ObterTodosAsync();
        Task<MotoEntity?> ObterUmAsync(int Id);
        Task<MotoEntity?> AdicionarAsync(MotoEntity entity);
        Task<MotoEntity?> EditarAsync(int Id, MotoEntity entity);
        Task<MotoEntity?> DeletarAsync(int Id);
    }
}
