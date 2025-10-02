using Challenge.Domain.Models;

namespace Challenge.Infrastructure.Data.Interfaces
{
    public interface IFialialRepository
    {
        Task<IEnumerable<FilialEntity>> ObterTodosAsync();
        Task<FilialEntity?> ObterUmAsync(int Id);
        Task<FilialEntity?> AdicionarAsync(FilialEntity entity);
        Task<FilialEntity?> EditarAsync(int Id, FilialEntity entity);
        Task<FilialEntity?> DeletarAsync(int Id);
    }
}
