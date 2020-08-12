using Microsoft.Extensions.DependencyInjection;
using Org.WingTipToy.ProductApi.BusinessLogic.Repositories;
using Org.WingTipToy.ProductApi.DataEntity.ConfigSections;

namespace Org.WingTipToy.ProductApi.BusinessLogic.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static void AddBusinessAccessDependency(this IServiceCollection services)
        {
            services.AddTransient<IDataRepository, DataRepository>();
            services.AddTransient<ProductContext>()
                .AddTransient<DbConnectionSettings>();
        }
    }
}
