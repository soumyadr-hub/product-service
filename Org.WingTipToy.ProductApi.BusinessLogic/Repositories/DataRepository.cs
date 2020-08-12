using Org.WingTipToy.ProductApi.DataEntity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Org.WingTipToy.ProductApi.BusinessLogic.Repositories
{
    public class DataRepository : IDataRepository
    {
        public DataRepository(ProductContext productContext)
        {
            ProductContext = productContext;
        }

        public ProductContext ProductContext { get; }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            var categories = await Task.Run(() => ProductContext.Categories.ToList()).ConfigureAwait(false);

            return categories;
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            var products = await Task.Run(() => ProductContext.Products.ToList()).ConfigureAwait(false);

            return products;
        }

        public async Task<IList<Product>> GetProductsAsync(int categoryId)
        {
            var filteredProducts = await Task.Run(async () =>
            {
                var products = await GetProductsAsync().ConfigureAwait(false);

                var productByCategoryQuery = from product in products
                                             where product.CategoryID.Equals(categoryId)
                                             select product;

                return productByCategoryQuery.ToList();
            }).ConfigureAwait(false);

            return filteredProducts;
        }
    }
}
