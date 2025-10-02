using Microsoft.EntityFrameworkCore;
using Challenge.Domain.Models;

namespace Challenge.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


        public DbSet<UsuarioEntity> Usuario { get; set; }

        public DbSet<MotoEntity> Moto { get; set; }

        public DbSet<FilialEntity> Filial { get; set; }

    }
    
}
