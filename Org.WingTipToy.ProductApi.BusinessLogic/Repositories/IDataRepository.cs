using Org.WingTipToy.ProductApi.DataEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Org.WingTipToy.ProductApi.BusinessLogic.Repositories
{
    public interface IDataRepository
    {
        Task<IList<Category>> GetCategoriesAsync();

        Task<IList<Product>> GetProductsAsync();

        Task<IList<Product>> GetProductsAsync(int categoryId);
    }
}
