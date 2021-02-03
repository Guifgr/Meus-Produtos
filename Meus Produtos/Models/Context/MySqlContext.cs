using Microsoft.EntityFrameworkCore;

namespace Meus_Produtos.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {

        }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
