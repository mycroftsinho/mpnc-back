using System.Linq;
using dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace data.Contexto
{
    public class BuscadorContexto : DbContext
    {
        private readonly IConfiguration _config;

        public BuscadorContexto(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Loja> Loja { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.AsProperty().Builder.HasMaxLength(256, ConfigurationSource.Convention);
                property.Relational().ColumnType = "varchar(256)";
            }

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // define the database to use
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }
    }
}