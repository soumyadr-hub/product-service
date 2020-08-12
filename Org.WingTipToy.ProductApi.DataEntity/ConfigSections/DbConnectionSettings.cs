using Microsoft.Extensions.Configuration;

namespace Org.WingTipToy.ProductApi.DataEntity.ConfigSections
{
    public class DbConnectionSettings
    {
        public DbConnectionSettings(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public string ConnectionString { get; }
    }
}
