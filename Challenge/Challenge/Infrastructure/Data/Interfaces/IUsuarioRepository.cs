using Challenge.Domain.Models;

namespace Challenge.Infrastructure.Data.Interfaces
{
    public interface IUsuarioRepository 

    {
        Task<IEnumerable<UsuarioEntity>> ObterTodosAsync();
        Task<UsuarioEntity?> ObterUmAsync(int Id);
        Task<UsuarioEntity?> AdicionarAsync(UsuarioEntity entity);
        Task<UsuarioEntity?> EditarAsync(int Id, UsuarioEntity entity);
        Task<UsuarioEntity?> DeletarAsync(int Id);
    }
}
