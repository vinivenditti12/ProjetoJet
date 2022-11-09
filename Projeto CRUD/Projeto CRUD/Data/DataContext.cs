using Microsoft.EntityFrameworkCore;
using Projeto_CRUD.Model;

namespace Projeto_CRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
