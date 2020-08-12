using Microsoft.EntityFrameworkCore;
using Org.WingTipToy.ProductApi.DataEntity;
using Org.WingTipToy.ProductApi.DataEntity.ConfigSections;

namespace Org.WingTipToy.ProductApi.BusinessLogic
{
    public class ProductContext : DbContext
    {
        public ProductContext()
        {
        }

        public ProductContext(DbConnectionSettings dbConnectionSettings)
        {
            ConnectionString = dbConnectionSettings.ConnectionString;
        }

        public string ConnectionString { get; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
